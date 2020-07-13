using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Capinfo.Authorization.Authoritys;
using System.Collections.Generic;

namespace Capinfo.His
{
    [AutoMapFrom(typeof(Authority))]
    public class AuthorityTreeDto : AuditedEntityDto<int>
    {
        public string title { get; set; }
        public bool expand { get; set; }
        public bool selected { get; set; }
        public string MoudleName { get; set; }
        public int Father { get; set; }
        public string Path { get; set; }
        public string MenuIcon { get; set; }
        //public string Title { get; set; }
        public string ComponentName { get; set; }
        public string Component { get; set; }
        public string Permission { get; set; }
        public List<AuthorityTreeDto> children = new List<AuthorityTreeDto>();
        
    }
}
