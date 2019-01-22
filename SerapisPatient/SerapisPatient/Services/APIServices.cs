using Newtonsoft.Json;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.Patient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerapisPatient.Services
{
    public class APIServices
    {
        private string APIURL = "http://localhost:62575/api";
        HttpClient _httpClient = new HttpClient();

        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            var model = new RegisterPatient
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("", content); //add your requesturi as a string

            return response.IsSuccessStatusCode;// this should return a bool
        }
        public async Task<bool> CreateAppointment(Doctor enquiredDoctor, MedicalBuildingModel _medicalBuildingModel)
        {

            var model = new Appointment
            {

                DoctorBooked = enquiredDoctor,
                //MedicalBuildingBooked = _medicalBuildingModel
                //i edited out the above for the timebeing
            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync(APIURL + "/Bookings", content);

            return response.IsSuccessStatusCode;


        }
        public async Task<string> GetAccountDetails()
        {
            var model = new PatientUser
            {

            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _httpClient.GetAsync(APIURL + " ");

            return response.ToString();
        }
    }
}
