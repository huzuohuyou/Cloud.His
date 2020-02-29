using Capinfo.Controllers;
using Capinfo.His;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.IO;

namespace Capinfo.Web.Host.Controllers
{
    public class XlsxController : CapinfoControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        public XlsxController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Export()
        {
            try
            {
                //var service = new QuestionAppService(new );
                string sWebRootFolder = _hostingEnvironment.WebRootPath;
                string sFileName = "工作周报_吴海龙.xlsx";
                FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                //file.Delete();
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    //添加值
                    worksheet.Cells["B2"].Value = "姓名";//姓名
                    worksheet.Cells["F2"].Value = "日期";//日期
                    worksheet.Cells["F4"].Value = "解锁";//解锁
                    worksheet.Cells["F5"].Value = "权限";//权限
                    worksheet.Cells["F6"].Value = "现场";//现场
                    worksheet.Cells["F7"].Value = "咨询";//咨询
                    worksheet.Cells["F8"].Value = "开发";//开发
                    worksheet.Cells["F9"].Value = "网页66链接";//查询
                    package.Save();
                }
                return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }


    }
}