using System;
using System.Collections.Generic;

namespace SerapisPatient.Models.Patient.Supabase
{
    public class UserIdentity
    {
        public DateTime CreatedAt { get; set; }

        public string Id { get; set; }

        public Dictionary<string, object> IdentityData { get; set; } = new Dictionary<string, object>();

        public DateTime LastSignInAt { get; set; }
        public string Provider { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UserId { get; set; }
    }
}
