using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Capinfo.Authorization.Users;
using Capinfo.His.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Capinfo.His.Questions;

namespace Capinfo.His
{
    public class QuestionAppService : IQuestionAppService
    {
        private readonly UserManager _userManager;
        //public IAbpSession AbpSession { get; set; }
        ////通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Questions> _personRepository;

        public QuestionAppService(IRepository<Questions> repository, UserManager userManager)
        {
            _userManager = userManager;
            _personRepository = repository;
            //AbpSession = NullAbpSession.Instance;
        }
        [HttpPost]
        public bool AddRecord(QuestionDto dto)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDto, Questions>());
                var mapper = config.CreateMapper();
                var po = mapper.Map<Questions>(dto);

                po.CreatorUserId = _userManager.UserId.Value;
                po.CreationTime = DateTime.Now;

                var ok = _personRepository.Insert(po) != null;
                return ok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        [HttpGet]
        public string Export(bool week)
        {
            try
            {
                var hardQuestion = GetHardQuestion();
                var u = _userManager.GetUserById(_userManager.UserId.Value);
                var question = GetThisWeekQuestion(week);
                string sWebRootFolder = $@"D:\GitHub\Cloud.His\src\Capinfo.Web.Host\wwwroot"; //_hostingEnvironment.WebRootPath;
                string sFileName = "工作周报_吴海龙.xlsx";
                FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    //添加值
                    worksheet.Cells["B2"].Value = u.Name;//姓名
                    worksheet.Cells["G2"].Value = week?question.Date:"全部";//日期
                    worksheet.Cells["C6"].Value = question.Unlock?.Trim();//解锁
                    worksheet.Cells["C7"].Value = question.Authority?.Trim();//权限
                    worksheet.Cells["C8"].Value = question.OnSite?.Trim();//现场
                    worksheet.Cells["C5"].Value = question.Advisory?.Trim();//咨询
                    worksheet.Cells["C22"].Value = hardQuestion;//困难问题
                    //worksheet.Cells["F8"].Value = question.Dev?.Trim();//开发
                    //worksheet.Cells["C9"].Value = question.Query?.Trim();//查询
                    package.Save();
                }
                var str = $@"D:\GitHub\Cloud.His\src\Capinfo.Web.Host\bin\Debug\netcoreapp3.0\publish\wwwroot\{DateTime.Now.ToString("yyyy-MM-dd") }_{ u.Name}_周报.xlsx";
                var fi = new FileInfo(str);
                fi.Delete();
                file.CopyTo(str);
                return $@"http://capinfo.devops.com:21021/" + fi.Name;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //实现接口中的方法
        [HttpGet]
        public PageDto<QuestionDto> GetAllQuestion(string Keyword, int SkipCount, int MaxResultCount,string userId="0")
        {
            userId = userId == "0" ? "" : _userManager.UserId.Value.ToString();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions> all = _personRepository
                .GetAllList(r => 
               ( r.Question.Contains(Keyword ?? "")
            || r.Reason.Contains(Keyword ?? "")
            || r.Phone.Contains(Keyword ?? "")
            || r.Dept.Contains(Keyword ?? "")
            || r.Date.ToString().Contains(Keyword ?? "")
            || r.Answer.Contains(Keyword ?? ""))
            && r.CreatorUserId.ToString().Contains(userId))
                .OrderByDescending(r=>r.Date).ToList();
            List<Questions> people = all.Skip(SkipCount).Take(MaxResultCount).ToList();
            foreach (Questions item in people)
            {
                var dto = mapper.Map<QuestionDto>(item);
                resultSet.Add(dto);
            }
            return new PageDto<QuestionDto>
            {
                totalCount = all.Count,
                items = resultSet.ToArray()
            };
        }

        [HttpGet]
        public QuestionDto GetQuestion(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            var po = _personRepository.Get(id);
            var dto = mapper.Map<QuestionDto>(po);
            return dto;
        }


        [HttpDelete]
        public async Task DeleteAsync(EntityDto<int> input)
        {
            var po = await _personRepository.GetAsync(input.Id);
            await _personRepository.DeleteAsync(po);
        }

        public string GetHardQuestion()
        {
            var u = _userManager.GetUserById(_userManager.UserId.Value);
            List<Questions> questions = new List<Questions>();
            var begin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).AddDays(-(int)DateTime.Now.DayOfWeek == 0 ? -7 : -(int)DateTime.Now.DayOfWeek);
            var end = begin.AddDays(7); //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).AddDays(6 - (int)DateTime.Now.DayOfWeek == 0 ? -7 : -(int)DateTime.Now.DayOfWeek);

            questions = _personRepository
            .GetAllList(r =>
            r.CreatorUserId == u.Id
            && r.Date > begin
            && r.Date < end)
            .ToList();
            var s = string.Join("\n●", questions.Where(r => r.Question.Contains("反馈")).Select(r => r.Question));
            return s;
        }

        public WeekRecordDto GetThisWeekQuestion(bool week)
        {
            var result = new WeekRecordDto();
            var u = _userManager.GetUserById(_userManager.UserId.Value);
            result.Name = u.Name;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<Questions> people = new List<Questions>();
            var begin =new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,23,59,59).AddDays(-(int)DateTime.Now.DayOfWeek==0?-7: -(int)DateTime.Now.DayOfWeek);
            var end = begin.AddDays(7); //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).AddDays(6 - (int)DateTime.Now.DayOfWeek == 0 ? -7 : -(int)DateTime.Now.DayOfWeek);
            result.Date = $@"{begin.AddDays(1).ToString("yyyy-MM-dd")} - {end.ToString("yyyy-MM-dd")}";
            if (week)
            {
                people = _personRepository
                .GetAllList(r =>
                r.CreatorUserId == u.Id
                && r.Date > begin
                && r.Date < end)
                .ToList();
            }
            else
            {
                people = _personRepository
                .GetAllList(r => r.CreatorUserId == u.Id)
                .OrderByDescending(r => r.Date).ToList();
            }

            foreach (Questions item in people)
            {
                var dto = mapper.Map<QuestionDto>(item);
                if (item.Type.Equals(TYPES.Advisory))
                {
                    result.Advisory += $@"
{item.DateValue} {item.Phone} {item.Dept}{item.Question}{item.Reason}{item.Answer}";
                }
                else if (item.Type.Equals(TYPES.Authority))
                {
                    result.Authority += $@"
{item.DateValue} {item.Phone} {item.Dept}{item.Question}{item.Reason}{item.Answer}";
                }
                else if (item.Type.Equals(TYPES.OnSite))
                {
                    result.OnSite += $@"
{item.DateValue} {item.Phone} {item.Dept}{item.Question}{item.Reason}{item.Answer}";
                }
                else if (item.Type.Equals(TYPES.Unlock))
                {
                    result.Unlock += $@"
{item.DateValue} {item.Phone} {item.Dept}{item.Question}{item.Reason}{item.Answer}";
                }
            }
            return result;
        }


        [HttpPost]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                var filePath = @"F:\UploadingFiles\" + formFile.FileName.Substring(formFile.FileName.LastIndexOf("\\") + 1);//注意formFile.FileName包含上传文件的文件路径，所以要进行Substring只取出最后的文件名

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return null;// Ok(new { count = files.Count, size });
        }

        [HttpPost]
        public List<QuestionDto> SearchQuestion(QuestionFilterDto questionFilter)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions> questions = _personRepository
                .GetAll().ToList().Where(
                r => r
                .GetType()
                .GetProperty(questionFilter.Select)
                .GetValue(r)
                .ToString()
                .Contains(questionFilter.Value)).ToList();//.GetAllPatient();
            foreach (Questions item in questions)
            {
                var dto = mapper.Map<QuestionDto>(item);
                resultSet.Add(dto);
            }
            return resultSet;
        }

        [HttpPut]
        public bool UpdateRecord(QuestionDto dto)
        {
            //var item = GetQuestion(dto.Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDto, Questions>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Questions>(dto);
            //po.Images = item.Images;
            var ok = _personRepository.Update(po);

            return ok != null;
        }

        /// <summary>
        /// 上传一个文件，并返回文件上传成功后的信息
        /// </summary>
        /// <param name="File">要上传的文件实体</param>
        /// <returns>文件上传成功后返回的文件相关信息</returns>
        public async Task<FileUploadOutputDto> UploadFile(IFormFile File)
        {
            try
            {
                //文件的原始名称
                string FileOriginName = File.FileName;

                //读取文件保存的根目录
                string fileSaveRootDir = ConfigHelper.GetAppSetting("App", "FileRootPath");
                //读取办公管理文件保存的模块的根目录
                string fileSaveDir = ConfigHelper.GetAppSetting("App", "OAFiles");
                //文件保存的相对文件夹(保存到wwwroot目录下)
                string absoluteFileDir = fileSaveRootDir + "/" + fileSaveDir;

                //文件保存的路径(应用的工作目录+文件夹相对路径);
                string fileSavePath = $@"D:\wwwroot\";// Environment.CurrentDirectory + "/wwwroot/" + absoluteFileDir;
                if (!Directory.Exists(fileSavePath))
                {
                    Directory.CreateDirectory(fileSavePath);
                }

                //生成文件的名称
                string Extension = Path.GetExtension(FileOriginName);//获取文件的源后缀
                if (string.IsNullOrEmpty(Extension))
                {
                    throw new UserFriendlyException("文件上传的原始名称好像不对哦，没有找到文件后缀");
                }
                string fileName = Guid.NewGuid().ToString() + Extension;//通过uuid和原始后缀生成新的文件名

                //最终生成的文件的相对路径（xxx/xxx/xx.xx）
                string finalyFilePath = fileSavePath + "/" + fileName;

                FileUploadOutputDto result = new FileUploadOutputDto();


                //打开上传文件的输入流
                Stream stream = File.OpenReadStream();
                //创建输入流的reader
                //var fileType = stream.GetFileType();
                //文件大小
                result.FileLength = stream.Length;
                result.FileName = FileOriginName;
                result.FileType = Extension.Substring(1);
                result.FileUrl = absoluteFileDir + "/" + fileName;

                //开始保存拷贝文件
                FileStream targetFileStream = new FileStream(finalyFilePath, FileMode.OpenOrCreate);
                await stream.CopyToAsync(targetFileStream);


                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("文件上传失败，原因" + ex.Message);
            }
        }
    }
}
