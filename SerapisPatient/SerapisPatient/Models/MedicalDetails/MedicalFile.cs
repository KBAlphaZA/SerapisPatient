using System;
using System.Collections.Generic;
using System.Text;

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
