using System.Collections.Generic;

namespace SerapisPatient.Models.Practices
{
    public class PracticeDto
    {
        //[JsonConverter(typeof(ObjectIdConverter))]
        public string Id { get; set; }
        public string PracticeName { get; set; }

        public string PracticePicture { get; set; }
        public Location GPSCoordinates { get; set; }
            
        public Address PracticeAddress { get; set; }

        //public ObjectId PracticeID { get; set; }

        public double DistanceFromPractice { get; set; }

        public List<string> DoctorsAtPractice { get; set; }
        //public List<ObjectId> DoctorsAtPractice { get; set; }
        public int NumOfPatientsInPractice { get; set; }

        public string OperatingTime { get; set; }


        public PracticeContact ContactPractice { get; set; }
    }
}
