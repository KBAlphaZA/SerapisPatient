using System;
using System.Collections.Generic;

namespace SerapisPatient.Models
{
    public class SessionContext
    {
        public Dictionary<String, object> CacheData { get; set; }
        public Patient.Patient UserInfo { get; set; }
    }
}
