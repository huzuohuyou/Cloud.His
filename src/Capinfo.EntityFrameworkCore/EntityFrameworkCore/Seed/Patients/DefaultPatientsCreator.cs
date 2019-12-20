using Capinfo.His;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capinfo.EntityFrameworkCore.Seed.Patients
{
    public class DefaultPatientsCreator
    {
        private readonly CapinfoDbContext _context;
        private List<Patient> PatientsList = GetInitialGoods();
        public DefaultPatientsCreator(CapinfoDbContext context)
        {
            _context = context;
        }
        private static List<Patient> GetInitialGoods()
        {
            return new List<Patient>
            {
                new Patient{ PTNO="1",NAME="N1",GENDER="F"},
                new Patient{ PTNO="2",NAME="N2",GENDER="M"},
                new Patient{ PTNO="3",NAME="N3",GENDER="M"},
            };
        }

        public void Create()
        {
            CreateGoods();
        }
        /// <summary>
        /// 循环添加初始数据
        /// </summary>
        private void CreateGoods()
        {
            foreach (var goods in PatientsList)
            {
                AddGoodsIfNotExists(goods);
            }
        }
       
        private void AddGoodsIfNotExists(Patient item)
        {
            if (_context.Patient.IgnoreQueryFilters().Any(l => l.PTNO == item.PTNO))
            {
                return;
            }

            _context.Patient.Add(item);
            _context.SaveChanges();
        }
    }
}
