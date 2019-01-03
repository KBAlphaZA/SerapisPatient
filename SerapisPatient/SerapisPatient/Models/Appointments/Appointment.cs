using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.Models.Doctor;

namespace SerapisPatient.Models.Appointments
{
    public class Appointment
    {
        public bool IsSerapisBooking { get; set; }
        public bool HasSeenGp{get; set;}
        public string DateBooked { get; set; }
        public string TimeBooked { get; set; }
        public string Venue { get; set; }
        public Doctor.Doctor DoctorBooked { get; set; }
        //public Doctor
    }
}
