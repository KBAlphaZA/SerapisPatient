using SerapisPatient.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SerapisPatient.Models.SymptomsChecker
{
    public class Symptoms
    {
        public string ID { get; set; }

        //Using this as a placeholder image
        public string Icon { get; private set; } = FieldsOfExpertise.audiologyIcon;

        public string Name { get; set; }
    }
}
