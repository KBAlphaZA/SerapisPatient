using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class MedicalFile
    {
        public ObjectId Id { get; set; }
        public string File { get; set; }
        public string DateCreated { get; set; }
        public string TimeCreated { get; set; }
        public string TypeOfFile { get; set; }
    }
}
