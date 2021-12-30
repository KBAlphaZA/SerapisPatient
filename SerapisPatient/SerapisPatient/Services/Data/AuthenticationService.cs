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
using SerapisPatient.Helpers;
using SerapisPatient.Utils;
using System.ComponentModel;

namespace SerapisPatient.Services.Data
{
    public class AuthenticationService
    {
        //private string APIURL = "serapismedicalapi.azurewebsites.net/api/";
        //serapismedicalapi.azurewebsites.net
        private string APIURL = "https://serapismedicalapi.herokuapp.com/api/";
        /// <summary>
        /// This handles Google login and registration
        /// </summary>
        /// <returns></returns>
        public async Task<Patient> GoogleLogin(GoogleUser googleUser,string token)
        {
            
            using (HttpClient _httpClient = new HttpClient())
            {
                string FirstName = StringUtil.ExtractFirstNameFromFullName(googleUser.Name);

                APIURL = APIURL+"Account?socialid="+googleUser.Id+"&"+"firstname="+ FirstName+"&"+"lastname="+googleUser.FamilyName;

                var content = await _httpClient.GetStringAsync(APIURL);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<Patient>(content);
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(result))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(result);
                    Debug.WriteLine("RESPONSE =>" + "{0}={1}", name, value);
                }
                
                return result;
            }
            
        }

        /// <summary>
        /// This handles Facebook login and registration
        /// </summary>
        /// <returns>PatientUser Data</returns>
        public async Task<Patient> FacebookLogin(FacebookProfile profile)
        {
            string[] Names = profile.FullName.Split(' ');
            string Firstname = StringUtil.ExtractFirstNameFromFullName(profile.FullName);
            //if user has more than one name we need to decide if we should remove his other names or load all of them
            using (HttpClient _httpClient = new HttpClient())
            {
                var model = new Patient
                {
                    SocialID = profile.ID,
                    PatientFirstName = Firstname,
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
        public async Task<object> LoginAsync(string email, string password)
        {
            string appendedURlString = "/patient/{0}/{1}";
            appendedURlString = string.Format(APIURL, appendedURlString);

            using (HttpClient _httpClient = new HttpClient())
            {

                var response = await _httpClient.GetAsync(appendedURlString); //add your requesturi as a string
                if(!response.IsSuccessStatusCode)
                {
                    //Do map error to UI and return object.
                    return "no good";
                }

                Debug.WriteLine(@"\tTodoItem successfully deleted.");


                return response;// this should return a bool
            }

        }
        public void method()
        {

            /*var response = await _httpClient.GetAsync("http://chucknorris.com/api/dropkick");
            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserializer<YourClass>(json);*/
            }
        }
}

