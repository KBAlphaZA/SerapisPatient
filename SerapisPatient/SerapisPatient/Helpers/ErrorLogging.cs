using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SerapisPatient.Helpers
{
    public static class ErrorLogging
    {
        private static string APIAddress = "https://www.addressofApi/";

        //This method sends the error msg to the backend
        public async static void WriteErrorMsg(DateTime timeAndDateOfLogEntry, object errorMsg, object patientId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();

                }
            }
            catch(Exception Ex)
            {

            }
        }

    }
}
