using SerapisPatient.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Doctor
{
    public class Qualification
    {
        public string Degree { get; set; }

        public DateTime Graduated { get; set; }

        public string University { get; set; }

        public string Abbr { get; set; }

        public Specilization Specialization { get; set; }

        public string Specilizationabbr { get; set; }
    }
}
