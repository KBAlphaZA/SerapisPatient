using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SerapisPatient.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.GoogleClient.Shared;
using SerapisPatient.Models.Patient;

namespace SerapisPatient.Services.Data
{
    public class AuthenticationService
    {
        private string APIURL = "serapismedicalapi.azurewebsites.net/api/";
        //serapismedicalapi.azurewebsites.net
        //http://serapismedicalapi.herokuapp.com/api/



        /// <summary>
        /// This handles Google login and registration
        /// </summary>
        /// <returns></returns>
        public Task<bool> GoogleLogin(GoogleUser googleUser,string token)
        {
            using(HttpClient _httpClient = new HttpClient())
            {
                Patient _patient = new Patient();
                PatientContact contact = new PatientContact();

                _patient.PatientFirstName = googleUser.Name;
                _patient.PatientLastName = googleUser.FamilyName;
                contact.Email = googleUser.Email;
                _patient.Token = googleUser.Id.ToString();
                //var model = new Patient
                //{
                //    PatientFirstName = googleUser.Name,
                //    PatientLastName = googleUser.FamilyName, 
                //    PatientContactDetails = { Email = googleUser.Email }, 
                //    //WE NEED TO DO SOMETHING ABOUT THE TOKEN
                //    //token = googleUser.Id.ToString(),
                //    //Token = googleUser.Id.ToString()
                //};

                var json = JsonConvert.SerializeObject(_patient);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = _httpClient
                       .PostAsync("Account", content);
            }
            
            return null;
        }

        /// <summary>
        /// This handles Facebook login and registration
        /// </summary>
        /// <returns>PatientUser Data</returns>
        public async Task<Patient> FacebookLogin(FacebookProfile profile)
        {
            string[] Names = profile.FullName.Split(' ');
            //if user has more than one name we need to decide if we should remove his other names or load all of them
            using (HttpClient _httpClient = new HttpClient())
            {
                var model = new Patient
                {
                    SocialID = profile.ID,
                    PatientFirstName = Names[0],
                    PatientLastName = Names[Names.Length - 1],
                    PatientContactDetails = 
                    {
                        Email = profile.Email,
                        CellphoneNumber = "+27"
                    }
                    
                    
                    
                };
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                
                //URL: Account?SocialID&Firstname&LastName&emailaddress
                var response = await _httpClient
                    .PostAsync($"{APIURL}Account?SocialID={model.SocialID}&FirstName={model.PatientFirstName}&LastName={model.PatientLastName}&emailaddress={model.PatientContactDetails.Email}"
                    , content);

                // Debug.WriteLine($"{APIURL}Account?SocialID={model.SocialID}&FirstName={model.PatientFirstName}&LastName={model.PatientLastName}&emailaddress={model.Email}");

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
