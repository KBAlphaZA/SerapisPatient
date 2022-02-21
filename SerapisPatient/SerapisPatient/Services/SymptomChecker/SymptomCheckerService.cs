using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.SymptomsChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.Services.SymptomChecker
{
    public class SymptomCheckerService : ISymptomCheckerService
    {

        public List<Symptoms> GetAllSymptoms()
        {
            throw new NotImplementedException();
        }

        public List<Symptoms> GetAllSymptomsMock()
        {
            List<Symptoms> symptoms;

            symptoms = new List<Symptoms>()
            {
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="9", Name="Pain Breathing"},
                new Symptoms{ ID="10", Name="Backache"},
                new Symptoms{ ID="10", Name="Internal bleeding"},
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="9", Name="Pain Breathing"},
                new Symptoms{ ID="10", Name="Backache"},
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="9", Name="Pain Breathing"},
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="9", Name="Pain Breathing"},
                new Symptoms{ ID="10", Name="Backache"},
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="9", Name="Pain Breathing"},
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
                new Symptoms{ ID="9", Name="Pain Breathing"},
                new Symptoms{ ID="10", Name="Backache"},
                new Symptoms{ ID="1", Name="Back"},
                new Symptoms{ ID="2", Name="Flu"},
                new Symptoms{ ID="3", Name="Headache"},
                new Symptoms{ ID="4", Name="Leg"},
                new Symptoms{ ID="5", Name="Spine"},
                new Symptoms{ ID="6", Name="Brain"},
                new Symptoms{ ID="7", Name="Nose Bleed"},
                new Symptoms{ ID="8", Name="Chest"},
            };

            return symptoms;
        }

    }
}
