using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string APIURL = "http://serapismedicalapi.azurewebsites.net/api";
       
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
            _httpClient.Dispose();
            client.Dispose();

            return response.IsSuccessStatusCode;// this should return a bool
        }
        public async Task<bool> CreateAppointment(PatientUser patient, DateTime bookedDate , Doctor enquiredDoctor, MedicalBuildingModel medicalBuildingModel)
        {
            using(HttpClient _httpClient = new HttpClient())
            {
                string api = $"{APIURL}Bookings";
                var model = new Appointment
                {
                    BookingId = ObjectId.GenerateNewId(),
                    PatientId = patient.Id,
                    DateBooked = bookedDate,
                    Venue = new Address
                    {
                         EstblishmentName = "Grays Hospital",
                         AddressLineOne="",
                         AddressLineTwo="",
                         CityTown="",
                         PostalCode=""
                    },
                    DoctorsId =ObjectId.Parse(enquiredDoctor.Id),
                    IsSerapisBooking = false,
                    HasSeenGP = false
                };
                var json = JsonConvert.SerializeObject(model);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await _httpClient.PostAsync(api, content);


                return response.IsSuccessStatusCode;
            }

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
            _httpClient.Dispose();

            return response.ToString();
        }


        /// <summary>
        ///  <c a="GetDoctorsAsync"/>
        ///   Used for DoctorListView, so it
        /// Pulls All Doctors from the Cloud so far, but
        /// Should add more features for filters
        /// </summary>
        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            using(HttpClient _httpClient = new HttpClient())
            {
                string api = $"{APIURL}/doctor";
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<List<Doctor>>(content);

                return result;
            }
            

        }
        
        public async Task<List<MedicalBuildingModel>> GetAllMedicalBuildingsAsync()
        {

            using(HttpClient _httpClient = new HttpClient())
            {
                string api = $"{APIURL}/practice";
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<List<MedicalBuildingModel>>(content);
                return result;
            }
        }

    }
}
