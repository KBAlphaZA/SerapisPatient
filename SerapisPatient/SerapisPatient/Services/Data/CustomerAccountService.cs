using Newtonsoft.Json;
using SerapisPatient.Models;
using SerapisPatient.Models.Patient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerapisPatient.Services.Data
{
    public static class CustomerAccountService
    {
        private static string APIURL = "https://serapismedicalapi.herokuapp.com/api/";
        //private static string APIURL = "serapismedicalapi.azurewebsites.net/api/"; //Azure
        //private static string APIURL = "http://20.90.225.93/api/"; //Azure : K8s

        public static async Task<BaseResponse<Patient>> RetrieveUserInformationAsync(string id)
        {
            string appendedURlString = "";
            appendedURlString = $"{ APIURL}patient/{id}";

            using (HttpClient _httpClient = new HttpClient())
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(6);
                var response = await _httpClient.GetAsync(appendedURlString); //add your requesturi as a string
                    //Do map error to UI and return object.
                    var stringResponse = await response.Content.ReadAsStringAsync();

                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Patient>>(stringResponse);
                    return baseResponse;
                

                Debug.WriteLine(@"\tTodoItem successfully deleted.");


                //return new BaseResponse<Patient>() { status = false };// this should return a bool
            }
        }
        public static async Task<BaseResponse<Patient>> UpdateUserInformation(Patient patient)
        {
            string appendedURlString = "";
            appendedURlString = $"{ APIURL}patient";

            using (HttpClient _httpClient = new HttpClient())
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(6);
                var json = JsonConvert.SerializeObject(patient);
                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.PutAsync(appendedURlString,content ); //add your requesturi as a string

                if (response.IsSuccessStatusCode)
                {
                    //Do map error to UI and return object.
                    var stringResponse = await response.Content.ReadAsStringAsync();

                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Patient>>(stringResponse);
                    return baseResponse;
                }

                Debug.WriteLine(@"\tUpdateUserInformation successfully ran.");


                return new BaseResponse<Patient>() { status = false };// this should return a bool
            }
        }
    }
}
