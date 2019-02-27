using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Doctor
{
     public partial  class Doctor
    {
        //You can use.NET string type instead of ObjectId, You just need to decorate it with BsonRepresentation.If you use BsonDateTime,
        //    you will have the same conversion issue.This is a domain class in my project that uses those decorators.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string University { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Time { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<object> practices { get; set; }
        public string YearsOfExp { get; set; }
     }

    public partial class Qualification
    {
        public string Degree { get; set; }
        public long Graduated { get; set; }
        public string University { get; set; }
        public string Abbr { get; set; }
        public string Specilization { get; set; }    
        public string Specilizationabbr { get; set; }

    }

}
