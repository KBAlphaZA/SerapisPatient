using System;
using System.Collections.Generic;
using SerapisPatient.Enum;
using SerapisPatient.Models.MedicalDetails;
using SerapisPatient.Models.Appointments;
using Realms;

namespace SerapisPatient.Models.Patient
{
    public class Patient : RealmObject
    {
        [PrimaryKey]
        public string id { get; set; }
        public string SocialID { get; set; }
        
        public string PatientFirstName { get; set; }
        
        public string PatientLastName { get; set; }
        
        public string PatientMedicalAid { get; set; }
        
        public bool MedicalAidPatient { get; set; }
        
        public string PatientBloodType { get; set; }
        
        public int PatientAge { get; set; }
        
        [Ignored]
        public bool HasBloodPressure { get; set; }
        [Ignored]
        public bool IsDepenedent { get; set; }
        [Ignored]
        public List<ChronicDisease> ListOfChronicDisease { get; set; }
        [Ignored]
        public List<Medication> ListOfMedication { get; set; }
        [Ignored]
        public List<Allergies> ListOfAllergies { get; set; }
        [Ignored]
        public List<MedicalFile> MedicalRecords { get; set; }
        
        private string patientProfilePicture;


        [Ignored]
        public List<BookedAppointment> PastBookedAppointments { get; set; }
        public string PatientProfilePicture { get; set; }
        [Ignored]
        public Genders Gender { get; set; }
        [Ignored]
        public DateTime BirthDate { get; set; }
        [Ignored]
        public PatientContact PatientContactDetails { get; set; }
        
        public bool IsGoogle { get; set; }
        
        public bool IsFacebook { get; set; }
        
        public string Token { get; set; }

    }
}


