using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Capinfo.EntityFrameworkCore.Repositories;
using Capinfo.His;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.EntityFrameworkCore.His
{
    public class PatientRepository : IPatientRepository//CapinfoRepositoryBase<Patient, int>, IPatientRepository
    {
        //public readonly IRepository<Patient> _personRepository;
        //protected PatientRepository(IDbContextProvider<CapinfoDbContext> dbContextProvider) : base(dbContextProvider)
        //{
        //}
        public List<Patient> GetAllPatient()
        {
            return null;// _personRepository.GetAllList();
        }

    }
}
