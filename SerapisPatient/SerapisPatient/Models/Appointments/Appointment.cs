﻿using System;

namespace SerapisPatient.Models.Appointments
{
    public class BookingAppointment
    {
        public string BookingId { get; set; }

        public int LineNumber { get; set; }

        public string PatientID { get; set; }

        public DateTime DateAndTimeOfAppointment { get; set; }

        public bool HasSeenGP { get; set; }

        public bool IsSerapisBooking { get; set; }
        public string Duration { get; set; }

        // BN: MONGODB DOESNT SUPPORT TIMESPAN
        //public TimeSpan Duration { get; set; }

        public bool HasBeenToThisPractice { get; set; }

        public string DoctorsId { get; set; }

        //    [BsonElement("venue")]
        //    public Address Venue { get; set; }
        public string PracticeID { get; set; }
    }
}
