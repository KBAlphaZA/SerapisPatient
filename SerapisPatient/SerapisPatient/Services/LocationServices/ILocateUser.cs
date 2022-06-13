namespace SerapisPatient.Services.LocationServices
{
    interface ILocateUser
    {
        double UserLatitude { get; set; }
        double UserLongitude { get; set; }
        
    }
}
