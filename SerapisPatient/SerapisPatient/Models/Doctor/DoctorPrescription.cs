using MongoDB.Bson;
using SerapisPatient.Models.Delivery;

namespace SerapisPatient.Models.Doctor
{
    public class DoctorPrescription:Prescription
    {
        public Doctor PrescribingDoctor { get; set; }
        public ObjectId MedicationId { get; set; }
        
    }

}
