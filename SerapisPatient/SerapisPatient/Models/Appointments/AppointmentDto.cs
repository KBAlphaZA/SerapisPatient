using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Appointments
{
    public class AppointmentDto
    {
        public ObjectId AppointmentId { get; set; }

        public DateTime DateBooked { get; set; }

        public DateTime TimeBooked { get; set; }
    }
}
