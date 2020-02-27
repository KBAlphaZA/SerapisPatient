using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Practices
{
    public class PracticeDto
    {
        public string PracticeName { get; set; }

        public string PracticePicture { get; set; }

        public ObjectId PracticeID { get; set; }

        public double Distance { get; set; }

        public int NumberOfPatientsAtPractice { get; set; }

        public string OperatingTimes { get; set; }

        public string ContactNumber { get; set; }
    }
}
