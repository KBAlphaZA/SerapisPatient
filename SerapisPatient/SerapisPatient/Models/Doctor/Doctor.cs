using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SerapisPatient.Enum;
using System;
using System.Collections.Generic;

namespace SerapisPatient.Models.Doctor
{
    public partial class Doctor
    {
        //You can use.NET string type instead of ObjectId, You just need to decorate it with BsonRepresentation.If you use BsonDateTime,
        //    you will have the same conversion issue.This is a domain class in my project that uses those decorators.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders Gender { get; set; }

        public DateTime BirthDate { get; set; }


        public string ProfilePicture { get; set; }

        public List<Qualification> Qualifications { get; set; }

        public Specilization Specialization { get; set; }

        //public List<PracticeInformation> PracticesOwnedOrWorksAt { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> PracticesOwnedOrWorksAt { get; set; }

        //public List<AppointmentModel.Appointment> ListOfAppointments { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ListOfAppointments { get; set; }

        public DoctorUser User { get; set; }


    }

}
