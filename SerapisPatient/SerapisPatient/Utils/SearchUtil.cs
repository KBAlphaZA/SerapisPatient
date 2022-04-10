using SerapisPatient.Models.SymptomsChecker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerapisPatient.Enum;

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

        public static (string,string) GetDescriptionBySpecialist(FieldsOfExpertise expertise)
        {
            switch (expertise.ToString())
            {
                case "gp":
                    return (FieldsOfExpertise.gpIcon,"A doctor broadly trained in medicine");
                case "gynaecologist":
                    return (FieldsOfExpertise.gynaecologist,"specialises in women’s reproductive health");
                case "psychiatrist":
                    return (FieldsOfExpertise.psychiatrist,"specialises in women’s reproductive health");
                case "General surgeon":
                    return (FieldsOfExpertise.plasticSurgeon,"trained in pre- and post-operative procedures, as well as invasive surgical procedures on the organs and bodily systems");
                case "dermatologist":
                    return (FieldsOfExpertise.dermatologist, "A doctor who specialises primarily in the treatment of skin, hair & nails");
                default:
                    return (FieldsOfExpertise.gp, "Sorry, we couldn't get the description for this specialist ");
            }
        }
    }
}
