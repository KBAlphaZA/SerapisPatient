using MongoDB.Bson;
using SerapisPatient.Models.Appointments;

namespace SerapisPatient.Models.Patient
{
    public class PatientDto
    {
        public ObjectId PatientId { get; set; }

        public string ProfilePicture { get; set; }

        public bool MedicalAidPatient { get; set; }

        public AppointmentDto AppointmentSet { get; set; }

        public string FullName { get; set; }
    }
}
