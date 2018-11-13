using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Practices
{
    public class PracticeLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string TownOrCity { get; set; }
        public string Country { get; set; }
        public double Distance { get; set; }
    }
}
