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

        public string PracticePicture { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string PracticeName { get; set; }

        public Address PracticeAddress { get; set; }

        public double DistanceFromPractice { get; set; }

        public List<ObjectId> DoctorsAtPractice { get; set; }

        public int NumOfPatientsInPractice { get; set; }

        public string OperatingTime { get; set; }

        public PracticeContact ContactPractice { get; set; }

    }
}
