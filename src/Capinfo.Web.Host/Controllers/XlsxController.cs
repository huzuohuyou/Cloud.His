using System;
using System.IO;
using Capinfo.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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

        public IActionResult Export()

        {
            
            
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = "工作周报_吴海龙.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            //file.Delete();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // 添加worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($@"{DateTime.Now.Date.ToString("yyyy-MM-dd")}");
                //添加头
                worksheet.Cells["A1:F1"].Merge = true;
                worksheet.Cells[1, 1].Value = "工作周报";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 18;
                worksheet.Cells[1, 1].Style.Indent = 0;
                worksheet.Cells[2, 1].Value = "姓名";
                worksheet.Cells[2, 2].Value = "吴海龙";
                worksheet.Cells[2, 3].Value = "岗位";
                worksheet.Cells[2, 4].Value = "运维";
                worksheet.Cells["E2:F2"].Merge = true;
                worksheet.Cells[2, 5].Value = "日期：2020.02.17--2020.02.21";
                //worksheet.Cells[1, 3].Value = "Url";
                //添加值
                worksheet.Cells["F4"].Value = "解锁";//解锁
                worksheet.Cells["F5"].Value = "权限";//权限
                worksheet.Cells["F6"].Value = "现场";//现场
                worksheet.Cells["F7"].Value = "咨询";//咨询
                worksheet.Cells["F8"].Value = "编码";//编码
                package.Save();
            }
            return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);

        }

    }
}