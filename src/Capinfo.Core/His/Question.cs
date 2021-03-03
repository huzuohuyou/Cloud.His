using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Capinfo.His
{
    public class ImageDto
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Questions : Entity
    {
        public enum ROLES { Doctor = 1, Nurse = 2 };
        public enum KINDS { In = 1, Out = 2 };
        public enum TYPES { Advisory = 1, Unlock = 2, Authority = 3, OnSite = 4 };
        public DateTime Date { get; set; }
        public string DateValue { get { return Date.ToString("yyyy-MM-dd"); } }
        public string Phone { get; set; }
     
        public string Dept { get; set; }
      
        public string User { get; set; }
      
        public string Ptno { get; set; }
       
        public KINDS Kind { get; set; }
   
        public ROLES Role { get; set; }

        private TYPES _type;
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
            set
            {
                _type = value;
            }
        }

        public string Question { get; set; }
      
        public string Reason { get; set; }
 
        public string Answer { get; set; }

        public string Images { get; set; }
        public string[] ImageArray
        {
            get
            {
                var list = new List<string>();
                if (Images!=null)
                {
                    foreach (var item in Images.Split('|'))
                    {
                        if (!item.Equals(string.Empty))
                        {
                            list.Add($@"{item}");
                        }
                    }
                    
                    return list.ToArray();
                }
                return new string[] { };
            }
        }

        
        public  DateTime CreationTime { get; set; }

        public long CreatorUserId{ get; set; }

        public long  DeleterUserId { get; set; }

        public DateTime?DeletionTime{ get; set; }

        public string DisplayName{ get; set; }
        public bool IsDeleted{ get; set; }

        public DateTime? LastModificationTime{ get; set; }

        public long? LastModifierUserId{ get; set; }

       
    }
}
