using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Patient
{
    public class PatientBookingDto
    {
        public string id { get; set; }
        public string BookingId { get; set; }
        public string DoctorName { get; set; }
        public string PracticeName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
