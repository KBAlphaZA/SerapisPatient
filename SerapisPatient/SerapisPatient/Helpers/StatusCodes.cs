using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Helpers
{
    public static class StatusCodes
    {
        public readonly static string Successful = "SM00";
        public readonly static string UnSuccessful = "SM01";
        public readonly static string AuthenticonError = "SM11";
        public readonly static string DatabaseError = "SM12";
        public readonly static string FatalError = "SM13";
        public readonly static string DownTime = "SM14";
    }
}
