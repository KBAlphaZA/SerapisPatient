using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.Helpers;

namespace SerapisPatient.Services.LocationServices
{
    public class GoogleMapsService
    {
        public static string GenerateUrl(string nameOfPlace)
        {
            return string.Format(UrlConstants.searchPlace,UrlConstants.placesApiKey,nameOfPlace);
        }
    }
}
