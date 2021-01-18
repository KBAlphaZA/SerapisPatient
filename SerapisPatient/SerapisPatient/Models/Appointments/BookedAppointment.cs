using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Appointments
{
    public class BookedAppointment
    {
        public string BookedpatientId { get; set; }

        public Session AppointmentSession { get; set; }
    }
}
