using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.Authorization.Authoritys
{
    public class MoudleGroup : Entity
    {
        public string GroupName { get; set; }
        

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
