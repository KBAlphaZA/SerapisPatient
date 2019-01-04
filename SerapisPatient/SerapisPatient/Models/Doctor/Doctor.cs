using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Doctor
{
     public class Doctor
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string University { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Time { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<object> practices { get; set; }
        public string YearsOfExp { get; set; }
    }

}
