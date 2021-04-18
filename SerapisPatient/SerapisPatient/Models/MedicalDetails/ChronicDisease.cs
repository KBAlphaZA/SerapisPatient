using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.MedicalDetails
{
    public class ChronicDisease : RealmObject
    {
        public string Id { get; set; }
        public string ChronicDiseaseName { get; set; }
    }
}
