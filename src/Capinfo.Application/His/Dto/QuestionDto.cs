using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Capinfo.His.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Capinfo.His
{
    [AutoMapFrom(typeof(Questions))]
    public class QuestionDto : AuditedEntityDto<int>
    {
        public enum ROLES { Doctor = 1, Nurse = 2 };
        public enum KINDS { In = 1, Out = 2 };
        public enum TYPES { Advisory = 1, Unlock = 2, Authority = 3, OnSite = 4 };

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
        public string DateDisplayValue
        {
            get
            {
                return Date.ToString("yyyy-MM-dd");
            }
        }
        private string _phone;
        public string Phone
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_phone))
                {
                    var regex = new Regex(@"\d{4}", RegexOptions.Singleline);
                    string a = regex.Match(Question).Value;
                    return string.IsNullOrWhiteSpace(a) ? "" : $@"{a}";
                }
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
        private string _dept { get; set; }
        public string Dept
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_dept))
                {
                    var regex = new Regex("(?<txt>(?<= ).{1,3}?病区)|(?<txt>(?<= ).{1,3}?科)", RegexOptions.Singleline);
                    string a = regex.Match(Question).Value;
                    return string.IsNullOrWhiteSpace(a) ? "" : $@"{a}";
                }
                return _dept;
            }
            set
            {
                _dept = value;
            }
        }
        private string _user;
        public string User
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_user))
                {
                    var regex = new Regex(@"\d{6}", RegexOptions.Singleline);
                    string a = regex.Match(Question).Value;
                    return string.IsNullOrWhiteSpace(a) ? "" : $@"{a}";
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }
        private string _ptno;
        public string Ptno
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ptno))
                {
                    var regex = new Regex(@"\d{10}", RegexOptions.Singleline);
                    string a = regex.Match(Question).Value;
                    return string.IsNullOrWhiteSpace(a) ? "" : $@"{a}";
                }
                return _ptno;
            }
            set
            {
                _ptno = value;
            }
        }

        public KINDS Kind
        {
            get
            {
                if (Question.Contains("门诊"))
                {
                    return KINDS.Out;
                }
                if (Question.Contains("病区"))
                {
                    return KINDS.In;
                }
                return KINDS.In;
            }
        }

        public ROLES Role
        {
            get
            {
                if (Question.Contains("医生")|Question.Contains("科"))
                {
                    return ROLES.Doctor;
                }
                return ROLES.Nurse;
            }
        }

        public TYPES Type
        {
            get
            {
                if (Question.Contains("锁"))
                {
                    return TYPES.Unlock;
                }
                if (Question.Contains("到") || Question.Contains("现场") || Question.Contains("上线") || Question.Contains("培训"))
                {
                    return TYPES.OnSite;
                }
                if (Question.Contains("增加") || Question.Contains("权限"))
                {
                    return TYPES.Authority;
                }
               
                return TYPES.Advisory;
            }
        }

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
