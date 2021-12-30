using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class SessionContext
    {
        public Dictionary<String, object> CacheData { get; set; }
        public Dictionary<String, UserProfile> UserInfo { get; set; }
    }
}
