using SerapisPatient.Views;
using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SerapisPatient.Models.Appointments
{
    public partial class MedicalBuildingModel
    {
        //You can use.NET string type instead of ObjectId, You just need to decorate it with BsonRepresentation.If you use BsonDateTime,
        //    you will have the same conversion issue.This is a domain class in my project that uses those decorators.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
       
        public string PracticeName { get; set; }
        
        public string PracticePicture { get; set; }
       
        public Location Location { get; set; }
 
        public List<Doc> DoctorAvaliable { get; set; }
        ////public string Id { get; set; }
        public string MedicalBuildingImage { get; set; }
        ////public string about { get; set; }
        ////public string PracticeName { get; set; }
        ////public float ChartValue { get; set; } //This Must be value 0 - 100%
        //////public Chart ChartData { get; set; }
        public double Distance { get; set; }
        ////public PracticeLocation Address { get; set; }
        public int PatientsCurrentlyAtPractice { get; set; }
        ////public double AvgTimeSpent { get; set; } //The average time a pateint spends at a practice
        //////public Doctor doctor { get; set; }
        ////public Specilization FieldsSpecilized { get; set; }
        ////public BookedTimes BookedTimes { get; set; }
        ///[BsonElement("Appointments")]
        public List<Appointment> Appointments { get; set; }
    }
    public partial class Location
    {        
        public string Latitude { get; set; }
        
        public string Longitude { get; set; }

        public WorkAddress WorkAddress { get; set; }

    }
    public partial class WorkAddress
    {

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string TownOrCity { get; set; }

        public int Postal { get; set; } //might be a long type !=int

    }
    public partial class Doc
    {
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        public ObjectId docid { get; set; }
    }
    public partial class Appointment
    {
        // most attributes will take on the objectid formatted as a string
        [BsonId]
        public ObjectId appointmentId { get; set; }
        public string Patient { get; set; }
        public DateTime DateandTime { get; set; }
        public string Venue { get; set; }
        public string DoctorBooked { get; set; }
        //public Doctor.Doctor DoctorBooked { get; set; }
        public bool IsSerapisBooking { get; set; }
        public bool HasSeenGp { get; set; }
        public string DateBooked { get; set; }
        public string TimeBooked { get; set; }
    }
    public partial class BookedTimes
    {
        public DateTime Time { get; set; }
        public bool Avaliable { get; set; }
        public string PatientID { get; set; }
    }


}
