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
        public List<AuthorityTreeDto> children = new List<AuthorityTreeDto>();
        
    }
}
