using SerapisPatient.Models.SymptomsChecker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SerapisPatient.Utils
{
    public static class SearchUtil
    {

        public static List<Symptoms> SearchForSymptoms(string queryText,List<Symptoms> MainListOfSymptoms)
        {

            List<Symptoms> ListOfSymptoms = MainListOfSymptoms;

            Debug.WriteLine("Query string: [ " + queryText + " ]");

            List<Symptoms> templist = new List<Symptoms>();

            foreach (var symptom in ListOfSymptoms)
            {
                templist = ListOfSymptoms
                                .Where(x => x.Name.ToLower().Contains(queryText.ToLower()))
                                .ToList();
            }

            return templist;
        }

        public static Symptoms FindSymptomByName(List<Symptoms> list, string s)
        {
            return list.FirstOrDefault(x => String.Equals(x.Name, s, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
