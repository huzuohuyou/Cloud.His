using Abp.Domain.Entities;
using System;

namespace Capinfo.Authorization.Authoritys
{
    public class Authority : Entity
    {
        public string Title { get; set; }
        public long? Father { get; set; }
        public string Icon { get; set; }
        public string ComponentName { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public string DisplayName { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }
    }
}
