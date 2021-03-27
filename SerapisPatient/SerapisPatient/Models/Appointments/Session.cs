using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Appointments
{
    public class Session
    {
        public string Duration { get; set; }
        public DoctorsNote DoctorNote { get; set; }
    }
}
