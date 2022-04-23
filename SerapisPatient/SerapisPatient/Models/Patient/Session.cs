using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Patient.Supabase
{
    public class Session
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public UserSupabase User { get; set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime ExpiresAt()
        {
            DateTime dateTime = this.CreatedAt;
            dateTime = new DateTime(dateTime.Ticks);
            return dateTime.AddSeconds((double)this.ExpiresIn);
        }
    }
}
