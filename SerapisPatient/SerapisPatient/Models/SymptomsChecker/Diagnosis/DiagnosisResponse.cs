using System.Collections.Generic;

namespace SerapisPatient.Models.SymptomsChecker.Diagnosis
{
    public class DiagnosisResponse
    {
        public Issue Issue { get; set; }
        public List<Specialisation> Specialisation { get; set; }
    }
}