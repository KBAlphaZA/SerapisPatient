using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SerapisPatient.Models.Patient;
using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.Models.Doctor;
namespace SerapisPatient.Models
{
     public class PatientUser
    {
        [BsonId]
        public ObjectId Id { get; set; }

        
        public string FirstName { get; set; }

        
        public string Password { get; set; }

        
        public string ProfilePicture { get; set; }

        
        public string Surname { get; set; }

        
        public int Age { get; set; }

        
        public string EmailAddress { get; set; }

        
        public string Cellphone { get; set; }

        
        public string BloodType { get; set; }

        
        public string MedicalAid { get; set; }

        
        public bool HasDependencies { get; set; }

        
        public List<object> DependenciesDetails { get; set; }

        
        public List<string> Allergies { get; set; }

        
        public List<string> ChronicDisease { get; set; }

        
        public List<string> MedicationTaken { get; set; }

        
        public string Gender { get; set; }

        
        public Address HomeAddress { get; set; }

        
        public List<object> MedicalFiles { get; set; }

        
        public bool BloodPressure { get; set; }

        
        public List<string> DoctorsSeen { get; set; }

        
        public List<Appointments.Appointment> Appointments { get; set; }

        
        public List<AppointmentHistory> AppointmentHistory { get; set; }

        
        [JsonProperty("nextOfKins")]
        public List<object> NextOfKins { get; set; }
    }

    

    public partial class AppointmentHistory
    {
      
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("doctor")]
        public string Doctor { get; set; }

        [JsonProperty("specilization")]
        public string Specilization { get; set; }

        [JsonProperty("practice")]
        public string Practice { get; set; }
    }

   
}

