﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace Capinfo.His
{
    [AutoMapFrom(typeof(Questions))]
    public class QuestionDto : AuditedEntityDto<int>
    {
        public enum ROLES { Doctor=1, Nurse=2 };
        public enum KINDS { In=1, Out=2 };
        public enum TYPES { Advisory=1, Unlock=2, Authority=3, OnSite=4 };

        public DateTime Date { get; set; }

        public string Phone { get; set; }

        public string Dept { get; set; }

        public string User { get; set; }

        public string Ptno { get; set; }

        public KINDS Kind { get; set; }

        public ROLES Role { get; set; }

        public TYPES Type { get; set; }

        public string TypeName
        {
            get
            {
                if (Type.Equals(TYPES.Advisory))
                {
                    return "咨询";
                }
                else if (Type.Equals(TYPES.Authority))
                {
                    return "权限";
                }
                else if (Type.Equals(TYPES.OnSite))
                {
                    return "现场";
                }
                else if (Type.Equals(TYPES.Unlock))
                {
                    return "解锁";
                }
                else
                {
                    return "其他";
                }
            }
        }

        public string Question { get; set; }

        public string Reason { get; set; }

        public string Answer { get; set; }



        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public long DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public string DisplayName { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public string Content
        {
            get
            {
                return $@"{Date.ToString("yyyy-MM-dd")} 科室：{Dept} 电话：{Phone} 用户：{User} 问题：{Question} 原因：{Reason} 方案：{Answer}";
            }
        }
    }
}
