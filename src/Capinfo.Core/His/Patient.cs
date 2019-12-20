using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public class Patient: Entity//AuditedAggregateRoot<int> ,IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        //public string ID { get; set; }
        /// <summary>
        /// //患者编号
        /// </summary>
        public string PTNO { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string GENDER { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string BIRTHDATE { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNO { get; set; }
        /// <summary>
        /// 最初来院日
        /// </summary>
        public string STARTDATE { get; set; }
        /// <summary>
        /// 最终来院日
        /// </summary>
        public string LASTDATE { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string POST_CODE { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string HOME_ADDRESS { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string TEL { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string TEL1 { get; set; }
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string CPNO { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CARD_TYPE { get; set; }

        /// <summary>
        /// 其它证件号码
        /// </summary>
        public string CONSULT { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string MARRIAGE { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string NATION { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        public string NATIONALITY { get; set; }
        /// <summary>
        /// 工作
        /// </summary>
        public string WORK { get; set; }
        /// <summary>
        /// 单位邮编
        /// </summary>
        public string COMPANY_POST { get; set; }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string COMPANY_ADDRESS { get; set; }
        /// <summary>
        /// 单位电话
        /// </summary>
        public string COMPANY_TEL { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string COMPANY_NAME { get; set; }
        /// <summary>
        /// 出生地
        /// </summary>
        public string BIRTHPLACE { get; set; }
        /// <summary>
        /// 医保证编号
        /// </summary>
        public string GKIHO2 { get; set; }
        /// <summary>
        /// 病历号
        /// </summary>
        public string BANNO { get; set; }


        public  DateTime CreationTime { get; set; }

        public long CreatorUserId{ get; set; }

        public long  DeleterUserId { get; set; }

        public DateTime?DeletionTime{ get; set; }

        public string DisplayName{ get; set; }
        public bool IsDeleted{ get; set; }

        public DateTime? LastModificationTime{ get; set; }

        public long? LastModifierUserId{ get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
