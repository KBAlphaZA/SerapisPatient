using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.SymptomsChecker
{
    public class SymptomsListData 
    {
        public ViewSymptoms Item1 { get; set; }
        public ViewSymptoms Item2 { get; set; }

        public ViewSymptoms Item3 { get; set; }
        public ViewSymptoms Item4 { get; set; }
        public ViewSymptoms Item5 { get; set; }
    }

    public class ViewSymptoms
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string Item5 { get; set; }
    }
}
