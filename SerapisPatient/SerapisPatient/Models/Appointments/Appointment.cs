using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SerapisPatient.Models.Doctor;

namespace SerapisPatient.Models.Appointments
{
    public class Appointment
    {
        // most attributes will take on the objectid formatted as a string
        [BsonId]
        public ObjectId appointmentId { get; set; }
        public string Patient { get; set; }
        public DateTime DateandTime { get; set; }
        public string Venue { get; set; }
        public string DoctorBooked { get; set; }
        //public Doctor.Doctor DoctorBooked { get; set; }
        public bool IsSerapisBooking { get; set; }
        public bool HasSeenGp { get; set; }
        public string DateBooked { get; internal set; }
        public string TimeBooked { get; internal set; }
    }
}
