using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His.Dto
{
    public class PageDto<T>
    { 
    public int totalCount { get; set; }
        public T[] items { get; set; }
    }
    //public class PageDto<T>
    //{
    //    public Result<T> result { get; set; }
    //    public int targetUrl { get; set; }
    //    public bool success { get; set; }
    //    public string error { get; set; }
    //    public bool unAuthorizedRequest { get; set; }
    //}
}
