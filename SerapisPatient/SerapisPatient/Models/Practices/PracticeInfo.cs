using MongoDB.Bson;
using SerapisPatient.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Practices
{
    public class PracticeInfo
    {
        public ObjectId Id { get; set; }
        public string PracticeName { get; set; }
        public string PracticeImage { get; set; }
        public string PracticeBio { get; set; }
        public int NumOfPatientsInPractice { get; set; }
        public Location Location { get; set; }
        public string OperatingTime { get; set; }
        public PracticeContact ContactP { get; set; }
      
    }
}
