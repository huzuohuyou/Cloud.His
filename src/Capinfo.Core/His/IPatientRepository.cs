﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatient();
    }
}
