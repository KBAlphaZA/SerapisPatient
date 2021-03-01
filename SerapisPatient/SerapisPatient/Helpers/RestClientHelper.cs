using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SerapisPatient.Helpers
{
    public class RestClientHelper
    {
        
        //Need to create a mapping for responses
        public object Connector(ref object _object, string _url, string _data)
        {
            
            using (HttpClient _httpClient = new HttpClient())
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(_object);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(_url, content); //add your requesturi as a string
                _httpClient.Dispose();

                client.Dispose();
            }


            return _object;
        }
    }

}
