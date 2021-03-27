using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class Medication
    {
        public string DrugCode { get; set; }

        public string Dosage { get; set; }
        public string MedicationName { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        
    }
}
