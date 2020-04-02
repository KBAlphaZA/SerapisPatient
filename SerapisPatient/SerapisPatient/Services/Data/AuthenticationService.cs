using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SerapisPatient.Models;
using System.Threading.Tasks;
using System.Diagnostics;

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
                    LastName = Names[Names.Length - 1],
                    EmailAddress = profile.Email,
                    
                    
                };
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                
                //Account?SocialID&Firstname&LastName&emailaddress
                var response = await _httpClient
                    .PostAsync($"{APIURL}Account?SocialID={model.SocialId}&FirstName={model.FirstName}&LastName={model.LastName}&emailaddress={model.EmailAddress}"
                    , content);

                Debug.WriteLine($"{APIURL}Account?SocialID={model.SocialId}&FirstName={model.FirstName}&LastName={model.LastName}&emailaddress={model.EmailAddress}");

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
