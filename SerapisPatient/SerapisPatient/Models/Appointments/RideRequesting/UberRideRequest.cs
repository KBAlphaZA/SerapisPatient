using System;
using System.Net.Http;

namespace SerapisPatient.Models.Appointments.RideRequesting
{
    public  class UberRideRequest
    {
        private  string clientId;

        private  string clientSecret;

        private  string scope;

        //Redirect URL
        private string uberUrlRedirectAuth = "https://login.uber.com/oauth/v2/authorize?client_id={0}&response_type=code&scope=profile";

        public UberRideRequest(string _clientId, string _clientSecret, string _scope)
        {
            clientId = _clientId;

            clientSecret = _clientSecret;

            scope = _scope;
        }

        //Gets the users permission to uber ride request
        public void GetUserUberProfile()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Get the users profile
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Find all the products availiable to the authorized user
        public void GetUberProducts(float latitude, float longitude)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Use the url to ask for uber products the user can ask for to go to practice
                }
                catch (Exception ex)
                {

                }
            }
        }

        //Asks uber patient to 
        public void GetUberRide(float start_latitude, float start_longitude, float end_latitude, float end_longitude, string fare_Id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Use the url to ask for uber ride
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
