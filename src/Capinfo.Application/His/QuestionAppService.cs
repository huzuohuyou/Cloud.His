using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Capinfo.His.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Capinfo.His
{
    public class QuestionAppService : IQuestionAppService
    {
        //通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Questions> _personRepository;

        public QuestionAppService(IRepository<Questions> repository)
        {
            _personRepository = repository;
        }
        [HttpPost]
        public bool AddRecord(QuestionDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDto, Questions>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Questions>(dto);
            var ok = _personRepository.Insert(po) != null;
            return ok;
        }

        //实现接口中的方法
        [HttpGet]
        public PageDto<QuestionDto> GetAllQuestion(string Keyword, int SkipCount, int MaxResultCount)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions>  all = _personRepository.GetAll().ToList();
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

        public List<QuestionDto> GetThisWeekQuestion()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions> people = _personRepository.GetAll().ToList().Where(r => r.Date.DayOfWeek == DateTime.Now.DayOfWeek).ToList();//.OrderBy(r=>r.Date).ToList();//.GetAllPatient();
            foreach (Questions item in people)
            {
                var dto = mapper.Map<QuestionDto>(item);
                resultSet.Add(dto);
            }
            return resultSet;
        }

        private IHostingEnvironment _hostingEnvironment;
        //public IActionResult Export()

        //{
        //    string sWebRootFolder = _hostingEnvironment.WebRootPath;
        //    string sFileName = "工作周报_吴海龙.xlsx";
        //    FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        //    file.Delete();
        //    using (ExcelPackage package = new ExcelPackage(file))
        //    {
        //        // 添加worksheet
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("部落");
        //        //添加头
        //        worksheet.Cells[1, 1].Value = "ID";
        //        worksheet.Cells[1, 2].Value = "Name";
        //        worksheet.Cells[1, 3].Value = "Url";
        //        //添加值
        //        worksheet.Cells["A2"].Value = 1000;
        //        worksheet.Cells["B2"].Value = "For丨丶";
        //        worksheet.Cells["C2"].Value = "网页链接";
        //        worksheet.Cells["A3"].Value = 1001;
        //        worksheet.Cells["B3"].Value = "For丨丶Tomorrow";
        //        worksheet.Cells["C3"].Value = "网页链接";
        //        worksheet.Cells["C3"].Style.Font.Bold = true;
        //        package.Save();
        //    }
        //    return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);

        //}

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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDto, Questions>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Questions>(dto);
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
                string fileSavePath = Environment.CurrentDirectory + "/wwwroot/" + absoluteFileDir;
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
