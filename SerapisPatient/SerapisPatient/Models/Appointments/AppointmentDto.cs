using MongoDB.Bson;
using System;

namespace SerapisPatient.Models.Appointments
{
    public class AppointmentDto
    {
        public ObjectId AppointmentId { get; set; }

        public DateTime DateBooked { get; set; }

        public DateTime TimeBooked { get; set; }
    }
}
