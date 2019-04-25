using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SerapisPatient.Models.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
     public class PatientUser
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("profilePicture")]
        public string ProfilePicture { get; set; }

        [JsonProperty(";astName")]
        public string Surname { get; set; }

        [JsonProperty("age")]
        public Age Age { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("cellphone")]
        public string Cellphone { get; set; }

        [JsonProperty("bloodType")]
        public string BloodType { get; set; }

        [JsonProperty("medicalAid")]
        public string MedicalAid { get; set; }

        [JsonProperty("hasDependencies")]
        public bool HasDependencies { get; set; }

        [JsonProperty("numOfDependencies")]
        public Age NumOfDependencies { get; set; }

        [JsonProperty("dependenciesDetails")]
        public List<object> DependenciesDetails { get; set; }

        [JsonProperty("allergies")]
        public List<string> Allergies { get; set; }

        [JsonProperty("chronicDisease")]
        public List<string> ChronicDisease { get; set; }

        [JsonProperty("medicationTaken")]
        public List<string> MedicationTaken { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeAddress")]
        public HomeAddress HomeAddress { get; set; }

        [JsonProperty("medicalFiles")]
        public List<object> MedicalFiles { get; set; }

        [JsonProperty("bloodPressure")]
        public bool BloodPressure { get; set; }

        [JsonProperty("doctorsSeen")]
        public List<string> DoctorsSeen { get; set; }

        [JsonProperty("appointments")]
        public List<object> Appointments { get; set; }

        [JsonProperty("appointmentHistory")]
        public List<AppointmentHistory> AppointmentHistory { get; set; }

        [JsonProperty("selfPrescriptionHistory")]
        public List<SelfPrescriptionHistory> SelfPrescriptionHistory { get; set; }

        [JsonProperty("prescribedMedicationHistory")]
        public List<PrescribedMedicationHistory> PrescribedMedicationHistory { get; set; }

        [JsonProperty("precribedMedication")]
        public List<object> PrecribedMedication { get; set; }

        [JsonProperty("nextOfKins")]
        public List<object> NextOfKins { get; set; }
    }

    public partial class Age
    {
        [JsonProperty("$numberInt")]
        public long NumberInt { get; set; }
    }

    public partial class AppointmentHistory
    {
        [JsonProperty("date")]
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

    public partial class HomeAddress
    {
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("townOrCity")]
        public string TownOrCity { get; set; }

        [JsonProperty("postalCode")]
        public long PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public partial class Id
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }

    public partial class PrescribedMedicationHistory
    {
        [JsonProperty("medication")]
        public string Medication { get; set; }

        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        [JsonProperty("dosage")]
        public string Dosage { get; set; }

        [JsonProperty("datePrescribed")]
        public string DatePrescribed { get; set; }
    }

    public partial class SelfPrescriptionHistory
    {
        [JsonProperty("prescriptionMedicine")]
        public string PrescriptionMedicine { get; set; }

        [JsonProperty("dosageAmountSelfPres")]
        public string DosageAmountSelfPres { get; set; }

        [JsonProperty("orderDate")]
        public string OrderDate { get; set; }

        [JsonProperty("recoveredTime")]
        public string RecoveredTime { get; set; }
    }
}

