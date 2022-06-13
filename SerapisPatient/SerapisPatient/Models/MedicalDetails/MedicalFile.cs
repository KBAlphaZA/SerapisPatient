using System;

namespace SerapisPatient.Models.MedicalDetails
{
    public class MedicalFile
    {
        public string Id { get; set; }
        public string File { get; set; }
        public DateTime DateAndTimeCreated { get; set; }
        public string TypeOfFile { get; set; }
    }
}
