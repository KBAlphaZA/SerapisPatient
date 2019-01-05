using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace SerapisPatient.Services.LocationServices
{
    interface ILocateUser
    {
        double UserLatitude { get; set; }
        double UserLongitude { get; set; }
        
    }
}
