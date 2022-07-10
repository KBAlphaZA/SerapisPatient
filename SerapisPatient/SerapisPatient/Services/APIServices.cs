using MongoDB.Bson;
using Newtonsoft.Json;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.Practices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SerapisPatient.Services
{
    public class APIServices
    {
       

        private string APIURL = "https://serapismedicalapi.azurewebsites.net/api"; //<- AZURE
        //private string APIURL = "https://serapismedicalapi.herokuapp.com/api"; 

        //GET
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            string appendedURlString = "/patient/{0}/{1}";
            appendedURlString = string.Format(APIURL,appendedURlString);

            using (HttpClient _httpClient = new HttpClient())
            {

                

                var response = await _httpClient.GetAsync(appendedURlString); //add your requesturi as a string
                _httpClient.Dispose();

                Debug.WriteLine(" Booking Creation Response =>[" + response.ToJson() + "]");
                return response.IsSuccessStatusCode;// this should return a bool
            }
               
        }
        
        public async Task<bool> CreateAppointment(string currentUser,DateTime bookedDate , Doctor enquiredDoctor, PracticeDto medicalBuildingModel )
        {
            using(HttpClient _httpClient = new HttpClient())
            {
                string api = $"{APIURL}/Booking?";
                //string api = $"{APIURL}/Booking?id={medicalBuildingModel.Id}";
                //string api = $"{APIURL}/Booking?id=5bc8e04a1c9d44000088ad93";
                var appointment = new Models.Bookings.Booking();
                var appointmentSession = new Session()
                {
                    Duration = "30"
                };
                var session = new BookedAppointment()
                {
                    BookedpatientId = currentUser,
                    AppointmentSession = appointmentSession
                };
                appointment.id = ObjectId.GenerateNewId().ToString();
                appointment.BookingId = ObjectId.GenerateNewId().ToString();
                appointment.PracticeId = medicalBuildingModel.Id;
                appointment.DoctorsId = enquiredDoctor.Id;
                //appointment.AppointmentDateTime = bookedDate; //TODO: Fix this date thing
                appointment.AppointmentDateTime = DateTime.Parse("06/30/2022 14:30:00");
                appointment.BookedAppointment = session;


                appointment.HasSeenGP = false;
                //appointment = false;
                

                var json = JsonConvert.SerializeObject(appointment);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await _httpClient.PostAsync(api, content);
                Debug.WriteLine(" Booking Creation Response =>[" + response + "]");

                Debug.WriteLine("Returned Status Code => "+"[" + response.StatusCode + "]");
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
                string api = $"{APIURL}/v1/doctor";
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<List<Doctor>>(content);
                Debug.WriteLine(" GetDoctorsAsync Response =>[" + result.ToJson() + "]");
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
                Debug.WriteLine(" GetAllMedicalBuildingsAsync Response =>[" + result.ToJson() + "]");
                return result;
            }
        }


        public async Task<List<PracticeDto>> GetAllMedicalBuildingsAsync(double lat, double lon, double radius)
        {
            using(HttpClient _httpClient =new HttpClient())
            {
                string api = string.Format(APIURL, "/Practices/{0}/{1}/{2}", lat, lon, radius);

                var content = await _httpClient.GetStringAsync(api);

                var result = JsonConvert.DeserializeObject<List<PracticeDto>>(content);
                Debug.WriteLine(" GetAllMedicalBuildingsAsync Response =>[" + result.ToJson() + "]");
                return result;
            }
        }

        public async Task<Patient> EditPatient()
        {
            Patient patient = new Patient();

            using (HttpClient _httpClient = new HttpClient())
            {

               /* var model = new Patient
                {
                    SocialID = googleUser.Id,
                    PatientFirstName = googleUser.Name,
                    PatientLastName = googleUser.FamilyName,
                    PatientContactDetails = new PatientContact { Email = googleUser.Email },
                    //WE NEED TO DO SOMETHING ABOUT THE TOKEN
                    //token = googleUser.Id.ToString()
                };*/

                //var response = await _httpClient.GetAsync(APIURL + "Account");
                APIURL = APIURL + "Account?socialid="+"&" + "firstname=" +"lastname=";

                var content = await _httpClient.GetStringAsync(APIURL);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<Patient>(content);
                Debug.WriteLine("RESPONSE =>" + result);
                return result as Patient;
            }

        }
    }
}
