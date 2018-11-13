using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Helpers
{
    public class UrlConstants
    {
        //place app registered crendtials for the maps api

        public const string placesApiKey = "AIzaSyBFNEpVt78wWQSdBmY9p1EMwrhVj3e2z6M";

        public const string searchPlace ="https://maps.googleapis.com/maps/api/place/queryautocomplete/json?key={0}&input={1}%20par";
    }
}
