using SerapisPatient.Models.Patient.Supabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Patient.Supabase
{
    public class UserSupabase
    {
        public string? ActionLink { get; set; }

        public Dictionary<string, object> AppMetadata { get; set; } = new Dictionary<string, object>();

        public string Aud { get; set; }

        public DateTime? ConfirmationSentAt { get; set; }

        public DateTime? ConfirmedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Email { get; set; }

        public DateTime? EmailConfirmedAt { get; set; }

        public string Id { get; set; }

        public List<UserIdentity> Identities { get; set; } = new List<UserIdentity>();

        public DateTime? InvitedAt { get; set; }

        public DateTime? LastSignInAt { get; set; }

        public string? Phone { get; set; }
        public DateTime? PhoneConfirmedAt { get; set; }

        public DateTime? RecoverySentAt { get; set; }

        public string? Role { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Dictionary<string, object> UserMetadata { get; set; } = new Dictionary<string, object>();
    }
}
