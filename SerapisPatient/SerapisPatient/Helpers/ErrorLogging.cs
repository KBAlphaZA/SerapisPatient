using System;
using System.Net.Http;

namespace SerapisPatient.Helpers
{
    public static class ErrorLogging
    {
        private static string APIAddress = "https://www.addressofApi/";

        //This method sends the error msg to the backend
        public static void WriteErrorMsg(DateTime timeAndDateOfLogEntry, object errorMsg, object patientId)
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
                throw Ex;
            }
        }

    }
}
