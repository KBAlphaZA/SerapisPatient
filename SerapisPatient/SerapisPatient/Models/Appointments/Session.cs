using SerapisPatient.Models.Doctor;

namespace SerapisPatient.Models.Appointments
{
    public class Session
    {
        public string Duration { get; set; }
        public DoctorsNote DoctorNote { get; set; }
    }
}
