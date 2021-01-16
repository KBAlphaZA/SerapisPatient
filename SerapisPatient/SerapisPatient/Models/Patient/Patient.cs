using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Enum;
using SerapisPatient.Models.MedicalDetails;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models;

namespace SerapisPatient.Models.Patient
{
    public class Patient
    {
        public ObjectId id { get; set; }
        public string SocialID { get; set; }
        
        public string PatientFirstName { get; set; }
        
        public string PatientLastName { get; set; }
        
        public string PatientMedicalAid { get; set; }
        
        public bool MedicalAidPatient { get; set; }
        
        public string PatientBloodType { get; set; }
        
        public int PatientAge { get; set; }
        public bool HasBloodPressure { get; set; }
        public bool IsDepenedent { get; set; }
        public List<ChronicDisease> ListOfChronicDisease { get; set; }
        public List<Medication> ListOfMedication { get; set; }
       
        public List<Allergies> ListOfAllergies { get; set; }
        
        public List<MedicalFile> MedicalRecords { get; set; }
        
        private string patientProfilePicture;

        
        
        public List<BookedAppointment> PastBookedAppointments { get; set; }
        public string PatientProfilePicture { get; set; }
        
        public Genders Gender { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public PatientContact PatientContactDetails { get; set; }
        
        public bool IsGoogle { get; set; }
        
        public bool IsFacebook { get; set; }
        
        public string Token { get; set; }

    }
}


