using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SerapisPatient.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using SerapisPatient.Models.Patient;
using SerapisPatient.Helpers;
using SerapisPatient.Utils;
using System.ComponentModel;
using MongoDB.Bson;
using SerapisPatient.Enum;
using SerapisPatient.Models.Patient.Supabase;

namespace SerapisPatient.Services.Data
{
    public static class  AuthenticationService
    {
        //private string APIURL = "serapismedicalapi.azurewebsites.net/api/";
        //serapismedicalapi.azurewebsites.net
        private static string APIURL = "https://serapismedicalapi.herokuapp.com/api/";


        public static async Task<object> LoginAsync(string email, string password)
        {
            string appendedURlString = "/patient/{0}/{1}";
            appendedURlString = string.Format(APIURL, appendedURlString);

            using (HttpClient _httpClient = new HttpClient())
            {

                var response = await _httpClient.GetAsync(appendedURlString); //add your requesturi as a string
                if (!response.IsSuccessStatusCode)
                {
                    //Do map error to UI and return object.
                    return "no good";
                }

                Debug.WriteLine(@"\tTodoItem successfully deleted.");


                return response;// this should return a bool
            }

        }
        public static Patient DummyPatient()
        {
            Patient patient = new Patient();
            patient.id = ObjectId.GenerateNewId().ToString();
            patient.PatientFirstName = "Kayla";
            patient.PatientLastName = "Mkhize";
            patient.PatientAge = 26;
            patient.PatientBloodType = Enum.BloodType.O_NEGATIVE.ToString();
            patient.PatientProfilePicture = "user1";


            return patient;

        }


        ///
        public static async Task<BaseResponse<Patient>> RegisterUserViaSupabaseAsync(Patient patient)
        {
            string endpoint = ConstantValues.SerapisMedical_Heroku_BaseEndpoint+ConstantValues.SerapisMedical_Register_User_Via_Cell_And_Password;

            using (HttpClient _httpClient = new HttpClient())
            {      

                    var json = JsonConvert.SerializeObject(patient);
                    HttpContent content = new StringContent(json);

                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                _httpClient.Timeout = TimeSpan.FromSeconds(6);
                    var response = await _httpClient
                        .PostAsync(endpoint, content);

                 var stringResponse = await response.Content.ReadAsStringAsync();

                var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Patient>>(stringResponse);
                return baseResponse;

            }
        }
        public static async Task<BaseResponse<PatientAuthResponse>> LoginUserViaSupabaseAsync(SupabaseAuth patient)
        {
            string endpoint = ConstantValues.SerapisMedical_Heroku_BaseEndpoint + ConstantValues.SerapisMedical_Login_User_Via_Cell_And_Password;

            using (HttpClient _httpClient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(patient);
                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                _httpClient.Timeout = TimeSpan.FromSeconds(6);
                var response = await _httpClient
                    .PostAsync(endpoint, content);

                var stringResponse = await response.Content.ReadAsStringAsync();

                var baseResponse = JsonConvert.DeserializeObject<BaseResponse<PatientAuthResponse>>(stringResponse);

                return baseResponse;

            }
        }
    }
}

