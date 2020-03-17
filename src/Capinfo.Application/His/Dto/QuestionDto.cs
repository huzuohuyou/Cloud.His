using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Capinfo.His.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capinfo.His
{
    [AutoMapFrom(typeof(Questions))]
    public class QuestionDto : AuditedEntityDto<int>
    {
        public enum ROLES { Doctor=1, Nurse=2 };
        public enum KINDS { In=1, Out=2 };
        public enum TYPES { Advisory=1, Unlock=2, Authority=3, OnSite=4 };

        private DateTime? _date;
        public DateTime Date
        {
            get
            {
                return _date ?? DateTime.Now;
            }
            set
            {
                _date = value;
            }
        }

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

        public string[] UploadList { get; set; }
        private string _images { get; set; }
        public string Images
        {
            get
            {
                var result = string.Empty;
                if (UploadList != null)
                {
                    UploadList.ToList().ForEach(r =>
                    {
                        result += $@"|http://capinfo.devops.com:8081/" + r;
                    });
                    return result.Trim('|');// string.Join("|", UploadList);
                }
                else
                {
                    return _images;
                }
            }
            set
            {
                _images = value;
            }
        }



        public string[] ImageArray { get; set; }

        public ImageDto[] ImagesForIview
        {
            get
            {
                var list = new List<ImageDto>();
                if (ImageArray != null)
                {
                    foreach (var item in ImageArray)
                    {
                        if (!item.Equals(string.Empty))
                        {
                            list.Add(new ImageDto
                            {
                                name = item,
                                url = item
                            });
                        }

                    }

                    return list.ToArray();
                }
                return new ImageDto[] { };
            }
        }


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
