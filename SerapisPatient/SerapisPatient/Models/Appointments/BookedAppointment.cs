namespace SerapisPatient.Models.Appointments
{
    public class BookedAppointment
    {
        public string BookedpatientId { get; set; }

        public Session AppointmentSession { get; set; }
    }
}
