using MongoDB.Bson;
using SerapisPatient.Models.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
     public class PatientUser
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public List<string> ChronicDisease { get; set; }
        public List<Medication> MedicationTaken { get; set; }
        public bool IsDependent { get; set; }
        public bool HasBloodPressure { get; set; }
        public List<string> Allergies { get; set; }
        public List<MedicalFile> File { get; set; }
        public string BloodType { get; set; }
        public bool HasMedicalAid { get; set; }
        public MedicalAid MedicalAid { get; set; }
        public bool DeliveryEnabled { get; set; }
        public PatientContact Contact { get; set; }
        public bool Smoker { get; set; }
        public string Birthday { get; set; }
        public double Weight { get; set; }
        public NextOfKin NextOfKinContact { get; set; }
    }
}
