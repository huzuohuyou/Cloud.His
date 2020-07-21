using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Capinfo.Authorization.Authoritys;
using System.Collections.Generic;

namespace Capinfo.His
{
    public class Mate {
        public string title { get; set; }
    }
    [AutoMapFrom(typeof(Authority))]
    public class AuthorityTreeDto : AuditedEntityDto<int>
    {
        public string title { get; set; }
        //public string name { get; set; }
        public Mate mate
        {
            get
            {
                return new Mate { title = this.title };
            }
        }
        public bool? IsActive { get; set; }
        public int? Father { get; set; }
        public string Icon { get; set; }
        public string ComponentName { get; set; }
        public List<AuthorityTreeDto> children = new List<AuthorityTreeDto>();
        
    }
}
