using Newtonsoft.Json;
using System;
using System.Net.Http;
using SerapisPatient.Models;
using System.Threading.Tasks;
using SerapisPatient.Models.Patient;
using SerapisPatient.Helpers;
using MongoDB.Bson;
using SerapisPatient.Models.Patient.Supabase;

namespace SerapisPatient.Services.Data
{
    public static class  AuthenticationService
    {
        private static string APIURL = "https://serapismedicalapi.azurewebsites.net/api/";
        //serapismedicalapi.azurewebsites.net
        //private static string APIURL = "https://serapismedicalapi.herokuapp.com/api/";

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
            string endpoint = ConstantValues.SerapisMedical_Azure_BaseEndpoint+ConstantValues.SerapisMedical_Register_User_Via_Cell_And_Password;

            try
            {
                using HttpClient _httpClient = new HttpClient();
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
            catch (Exception)
            {

                return new BaseResponse<Patient>() { status = false, StatusCode = StatusCodes.AuthenticonError, message = "Failure", data = new Patient()};
            }
        }
        public static async Task<BaseResponse<PatientAuthResponse>> LoginUserViaSupabaseAsync(SupabaseAuth patient)
        {
            string endpoint = ConstantValues.SerapisMedical_Azure_BaseEndpoint + ConstantValues.SerapisMedical_Login_User_Via_Cell_And_Password;

            using HttpClient _httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(patient);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _httpClient.Timeout = TimeSpan.FromSeconds(6);
                
            var response = await _httpClient.PostAsync(endpoint, content);
                
            if (!response.IsSuccessStatusCode)
            {
                if( response.StatusCode.ToString() == "503")
                {
                    return new BaseResponse<PatientAuthResponse>()
                    {
                        status = false,
                        message = "Service Unavailable"
                    };
                }
                else
                {
                    return new BaseResponse<PatientAuthResponse>()
                    {
                        status = false,
                        message = "Invalid Credentials"
                    };
                }
            }
            var stringResponse = await response.Content.ReadAsStringAsync();

            var baseResponse = JsonConvert.DeserializeObject<BaseResponse<PatientAuthResponse>>(stringResponse);

            return baseResponse;
        }
    }
}

