using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SerapisPatient.Models;
using System.Threading.Tasks;

namespace SerapisPatient.Services.Data
{
    public class AuthenticationService
    {
        private string APIURL = "http://serapismedicalapi.herokuapp.com/api/";

        /// <summary>
        /// This handles Facebook login and registration
        /// </summary>
        /// <returns></returns>
        public async Task<PatientUser> FacebookLogin(FacebookProfile profile)
        {
            string[] Names = profile.FullName.Split(' ');
            //if user has more than one name we need to decide if we should remove his other names or load all of them
            using (HttpClient _httpClient = new HttpClient())
            {
                var model = new PatientUser
                {
                    SocialId = profile.ID,
                    FirstName = Names[0],
                    Surname = Names[Names.Length - 1],
                    EmailAddress = profile.Email,
                    
                    
                };
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.PostAsync($"{APIURL}Account", content); //add your requesturi as a string
                // this should return a bool && this process needs to be re-evualted

                if (response.IsSuccessStatusCode)
                {
                    return model;
                }
                else
                {
                    //should return some kind of message telling us we couldnt login/create the user
                    return null;
                } 
            }
        }
    }
}
