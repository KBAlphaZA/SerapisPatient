using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class MedicalAid
    {
        public ObjectId Id { get; set; }
        public string NameOfMedicalAid { get; set; }
        public int NumberOfPeopleCovered{ get; set; }
        public string MedicalAidNumber { get; set; }
    }
}
