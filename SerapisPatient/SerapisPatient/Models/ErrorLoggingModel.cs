using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class ErrorLoggingModel
    {
        public DateTime TimeOfError { get; set; }
        public string ErrorMessage { get; set; }
        public PatientUser PatientId { get; set; }

        public string DeviceType { get; set; }
    }
}
