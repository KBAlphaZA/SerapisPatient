using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Appointments
{
    public class Appointment
    {
        public ObjectId BookingId { get; set; }
        public int LineNumber { get; set; }
        public DateTime DateBooked { get; set; }
        public DateTime TimeBooked { get; set; }
        public bool HasSeenGP { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsSerapisBooking { get; set; }
        public bool HasBeenToThisPractice { get; set; }

        public ObjectId PatientId { get; set; }

        public Address Venue { get; set; }

        public ObjectId DoctorsId { get; set; }
    }
}
