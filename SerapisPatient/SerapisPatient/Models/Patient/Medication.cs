using Realms;

namespace SerapisPatient.Models
{
    public class Medication : RealmObject
    {
        public string DrugCode { get; set; }

        public string Dosage { get; set; }
        public string MedicationName { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        
    }
}
