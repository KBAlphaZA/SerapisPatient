using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.Practices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerapisPatient.Services
{
    public class APIServices
    {
       

        //private string APIURL = "http://serapismedicalapi.azurewebsites.net/api"; <- AZURE
        private string APIURL = "https://serapismedicalapi.herokuapp.com/api"; 


        //public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        //{
        //    var client = new HttpClient();
        //    var model = new RegisterPatient
        //    {
        //        Email = email,
        //        Password = password,
        //        ConfirmPassword = confirmPassword
        //    };
        //    var json = JsonConvert.SerializeObject(model);

        //    HttpContent content = new StringContent(json);

        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //    var response = await client.PostAsync("", content); //add your requesturi as a string
        //    _httpClient.Dispose();
        //    client.Dispose();

        //    return response.IsSuccessStatusCode;// this should return a bool
        //}
        public async Task<bool> CreateAppointment( Patient patient, DateTime bookedDate , Doctor enquiredDoctor, PracticeDto medicalBuildingModel )
        {
            using(HttpClient _httpClient = new HttpClient())
            {
                //Booking/?id=5bc8e04a1c9d44000088ad93
                string api = $"{APIURL}/Bookings?id={medicalBuildingModel.Id}";
                var model = new Appointment
                {
                    BookingId = ObjectId.GenerateNewId(),
                    PatientID = patient.id.ToString(),
                    DateAndTimeOfAppointment = bookedDate,
                    DoctorsId =enquiredDoctor.Id,
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
        
        public async Task<ObservableCollection<PracticeDto>> GetAllMedicalBuildingsAsync()
        {

            using(HttpClient _httpClient = new HttpClient())
            {
                string api =string.Format(APIURL+"/Practice");
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<ObservableCollection<PracticeDto>>(content);
                return result;
            }
        }


        public async Task<List<PracticeDto>> GetAllMedicalBuildingsAsync(double lat, double lon, double radius)
        {
            using(HttpClient httpClient=new HttpClient())
            {
                string api = string.Format(APIURL, "/Practices/{0}/{1}/{2}", lat, lon, radius);

                var content = await _httpClient.GetStringAsync(api);

                var result = JsonConvert.DeserializeObject<List<PracticeDto>>(content);

                return result;
            }
        }


    }
}
