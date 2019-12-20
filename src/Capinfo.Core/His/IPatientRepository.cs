using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public interface IPatientRepository : IRepository
    {
        List<Patient> GetAllPatient();
    }
}
