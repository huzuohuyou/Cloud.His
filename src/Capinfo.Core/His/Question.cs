using Abp.Domain.Entities;
using System;

namespace Capinfo.His
{
    public class Questions : Entity
    {
        public enum ROLES { Doctor, Nurse };
        public enum KINDS { In, Out};
        public enum TYPES { Advisory, Unlock, Authority, OnSite };
  
        public DateTime Date { get; set; }
    
        public string Phone { get; set; }
     
        public string Dept { get; set; }
      
        public string User { get; set; }
      
        public string Ptno { get; set; }
       
        public KINDS Kind { get; set; }
   
        public ROLES Role { get; set; }
       
        public TYPES Type { get; set; }
 
        public string Question { get; set; }
      
        public string Reason { get; set; }
 
        public string Answer { get; set; }
       


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
