using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SerapisPatient.Models.Patient;
using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Enum;

namespace SerapisPatient.Models
{
     public class PatientUser
     {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("privateid")]
        public int PrivateId { get; set; }

        [BsonElement("socialid")]
        public string SocialId { get; set; }


        [BsonElement("token")]
        public string Token { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("confirmPassword")]
        public string ConfirmPassword { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("profilePicture")]
        public string ProfilePicture { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("age")]
        public Int32 Age { get; set; }

        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; }

        [BsonElement("cellphone")]
        public Int64 Cellphone { get; set; }

        [BsonElement("bloodType")]
        public string BloodType { get; set; }

        [BsonElement("medicalAid")]
        public string MedicalAid { get; set; }

        [BsonElement("hasDependencies")]
        public bool HasDependencies { get; set; }

        [BsonElement("numOfDependencies")]
        public int NumOfDependencies { get; set; }

        [BsonElement("dependenciesDetails")]
        public List<object> DependenciesDetails { get; set; }

        [BsonElement("allergies")]
        public List<string> Allergies { get; set; }

        [BsonElement("chronicDisease")]
        public List<string> ChronicDisease { get; set; }

        [BsonElement("medicationTaken")]
        public List<string> MedicationTaken { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("homeAddress")]
        public HomeAddress HomeAddress { get; set; }

        [BsonElement("medicalFiles")]
        public List<object> MedicalFiles { get; set; }

        [BsonElement("bloodPressure")]
        public bool BloodPressure { get; set; }

        [BsonElement("doctorsSeen")]
        public List<DoctorsSeen> DoctorsSeen { get; set; }

        [BsonElement("appointments")]
        public List<object> Appointments { get; set; }

        [BsonElement("appointmentHistory")]
        public List<AppointmentHistory> AppointmentHistory { get; set; }

        [BsonElement("selfPrescriptionHistory")]
        public List<SelfPrescriptionHistory> SelfPrescriptionHistory { get; set; }

        [BsonElement("prescribedMedicationHistory")]
        public List<PrescribedMedicationHistory> PrescribedMedicationHistory { get; set; }

        [BsonElement("precribedMedication")]
        public List<object> PrecribedMedication { get; set; }

        [BsonElement("nextOfKins")]
        public List<object> NextOfKins { get; set; }
    }


    public partial class DoctorsSeen
    {
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        public ObjectId docid { get; set; }
    }

    public partial class AppointmentHistory
    {

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("time")]
        public string Time { get; set; }

        [BsonElement("doctor")]
        public string Doctor { get; set; }

        [BsonElement("specilization")]
        public string Specilization { get; set; }

        [BsonElement("practiceName")]
        public string PracticeName { get; set; }


    }

    public partial class HomeAddress
    {
        [BsonElement("addressLine1")]
        public string AddressLine1 { get; set; }

        [BsonElement("addressLine2")]
        public string AddressLine2 { get; set; }

        [BsonElement("townOrCity")]
        public string TownOrCity { get; set; }

        [BsonElement("postalCode")]
        public long PostalCode { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }
    }

    public partial class Id
    {
        [BsonElement("$oid")]
        public string Oid { get; set; }
    }

    public partial class SelfPrescriptionHistory
    {
        [BsonElement("prescriptionMedicine")]
        public string PrescriptionMedicine { get; set; }

        [BsonElement("dosageAmountSelfPres")]
        public string DosageAmountSelfPres { get; set; }

        [BsonElement("orderDate")]
        public string OrderDate { get; set; }

        [BsonElement("recoveredTime")]
        public string RecoveredTime { get; set; }
    }

    public partial class PrescribedMedicationHistory
    {
        [BsonElement("medication")]
        public string Medication { get; set; }

        [BsonElement("instructions")]
        public string Instructions { get; set; }

        [BsonElement("dosage")]
        public string Dosage { get; set; }

        [BsonElement("datePrescribed")]
        public string DatePrescribed { get; set; }
    }
}

