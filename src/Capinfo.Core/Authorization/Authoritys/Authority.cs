﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.Authorization.Authoritys
{
    public class Authority : Entity
    {
        public string MoudleName { get; set; }
        public int Father { get; set; }
        public string Path { get; set; }
        public string MenuIcon { get; set; }
        public string Title { get; set; }
        public string ComponentName { get; set; }
        public string Component { get; set; }
        public string Permission { get; set; }

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