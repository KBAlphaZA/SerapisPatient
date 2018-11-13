using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class DependentPatient:PatientUser
    {
        public string Parent { get; set; }
    }
}
