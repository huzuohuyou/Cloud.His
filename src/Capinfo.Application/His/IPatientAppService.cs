using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public interface IPatientAppService : IApplicationService
    {
        List<PatientDto> GetAllPatient();
    }
}
