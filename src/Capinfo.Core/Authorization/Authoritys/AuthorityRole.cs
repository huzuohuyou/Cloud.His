using Abp.Domain.Entities;
using System;

namespace Capinfo.Authorization.Authoritys
{
    /// <summary>
    /// 角色权限关联实体
    /// </summary>
    public class AuthorityRole : Entity
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
