using System;
using SerapisPatient.Models.Appointments;

namespace SerapisPatient.Models.Bookings
{
    public class Booking
    {
        public string id { get; set; }
        
        public string BookingId { get; set; }
        
        public string PracticeId { get; set; }
        
        public string DoctorsId { get; set; }
        
        public BookedAppointment BookedAppointment { get; set; }
        
        public DateTime AppointmentDateTime { get;  set; }
        
        public bool HasSeenGP { get; set; }
        
        public DateTime CreatedDate { get; set; }        
    }
}
