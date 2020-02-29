using Abp.Application.Services;
using Abp.UI;
using Capinfo.His.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Capinfo.His
{
    /// <summary>
    /// 文件通用的接口 实现
    /// </summary>
    public class FileCommonService : ApplicationService, IFileCommonService
    {

        //private IHostingEnvironment _hostingEnvironment;
        //[HttpGet]
        //public string Export()
        //{
        //    string sWebRootFolder = _hostingEnvironment.WebRootPath;
        //    string sFileName = @"demo.xlsx";
        //    string URL = string.Empty;// string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
        //    FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        //    }
        //    using (ExcelPackage package = new ExcelPackage(file))
        //    {
        //        // add a new worksheet to the empty workbook
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employee");
        //        //First add the headers
        //        worksheet.Cells[1, 1].Value = "ID";
        //        worksheet.Cells[1, 2].Value = "Name";
        //        worksheet.Cells[1, 3].Value = "Gender";
        //        worksheet.Cells[1, 4].Value = "Salary (in $)";

        //        //Add values
        //        worksheet.Cells["A2"].Value = 1000;
        //        worksheet.Cells["B2"].Value = "Jon";
        //        worksheet.Cells["C2"].Value = "M";
        //        worksheet.Cells["D2"].Value = 5000;

        //        worksheet.Cells["A3"].Value = 1001;
        //        worksheet.Cells["B3"].Value = "Graham";
        //        worksheet.Cells["C3"].Value = "M";
        //        worksheet.Cells["D3"].Value = 10000;

        //        worksheet.Cells["A4"].Value = 1002;
        //        worksheet.Cells["B4"].Value = "Jenny";
        //        worksheet.Cells["C4"].Value = "F";
        //        worksheet.Cells["D4"].Value = 5000;

        //        package.Save(); //Save the workbook.
        //    }
        //    return URL;
        //}
    }
}
