using System;

namespace SerapisPatient.Models.Doctor
{
    public partial class DoctorUser
    {
        public string HealthId { get; set; }

        
        public string Password { get; set; }

        
        public string Email { get; set; }

        
        public string GivenCode { get; set; }

        
        public DateTime LastLogin { get; set; }

        public bool HasbeenValidated { get; set; }
    }
}
