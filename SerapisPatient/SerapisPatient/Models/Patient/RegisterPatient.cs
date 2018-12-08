using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Patient
{
    public class RegisterPatient
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
