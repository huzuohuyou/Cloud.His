using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Capinfo.Authorization.Authoritys;
using System;

namespace Capinfo.His
{
    [AutoMapFrom(typeof(AuthorityRole))]
    public class AuthorityRoleDto : AuditedEntityDto<int>
    {
        public long RoleId { get; set; }
        public long AuthorityId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }


    }
}
