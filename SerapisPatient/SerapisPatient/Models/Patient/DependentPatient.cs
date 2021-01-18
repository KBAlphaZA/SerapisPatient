using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.Models.Patient;
namespace SerapisPatient.Models
{
    public class DependentPatient : SerapisPatient.Models.Patient.Patient
    {
        public string Parent { get; set; }
    }
}
