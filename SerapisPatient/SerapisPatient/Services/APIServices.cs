using Newtonsoft.Json;
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
    }
}
