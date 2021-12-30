using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.SymptomsChecker;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.behavious
{
    public class SelectedItemEvent : EventArgs
    {
        public MedicalBuildingModel SelectedBuilding { get; set; }
        public Doctor SelectedDoctor { get; set; }
        public SpecilizationModel SelectedSpecilization { get; set; }
        public BookedTimes BookedTimes { get; set; }
        
        public Symptoms SelectedSymptoms { get; set; }

    }
}
