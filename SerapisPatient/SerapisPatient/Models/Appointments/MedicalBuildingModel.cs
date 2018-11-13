using SerapisPatient.Views;
using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Appointments
{
    public class MedicalBuildingModel
    {
        public string Id { get; set; }
        public string MedicalBuildingImage { get; set; }
        public string about { get; set; }
        public string PracticeName { get; set; }
        public float ChartValue { get; set; } //This Must be value 0 - 100%
        //public Chart ChartData { get; set; }
        public double Distance { get; set; }
        //public PracticeLocation Address { get; set; }
        public int PatientsCurrentlyAtPractice { get; set; }
        public double AvgTimeSpent { get; set; } //The average time a pateint spends at a practice
        //public Doctor doctor { get; set; }
        public Specilization FieldsSpecilized { get; set; }
    }
}
