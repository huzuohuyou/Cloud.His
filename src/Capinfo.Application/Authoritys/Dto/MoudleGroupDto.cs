using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Capinfo.Authorization.Authoritys;
using Capinfo.His.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capinfo.His
{
    [AutoMapFrom(typeof(MoudleGroup))]
    public class MoudleGroupDto : AuditedEntityDto<int>
    {
        public string GroupName { get; set; }


        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public long DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public string DisplayName { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        
    }
}
