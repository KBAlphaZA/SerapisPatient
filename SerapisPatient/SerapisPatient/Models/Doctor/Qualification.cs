using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Doctor
{
     public class Qualification
    {

        public ObjectId Id { get; set; }
        public string degree { get; set; }
        public string graduated { get; set; }
        public string university { get; set; }
        public string abbr { get; set; }
        public string specilization { get; set; }
        public string specilizationabbr { get; set; }

    }
}
