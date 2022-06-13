using System;
using SerapisPatient.Enum;

namespace SerapisPatient.Utils
{
    public static class StringUtil
    {

         /// <summary>
         /// For Some 3rd party API's we get the first name as a full name or multiple names, so we extract only the first name
         /// </summary>
         /// <param name="s"></param>
         /// <returns>String: Only the First Name</returns>
         public static string ExtractFirstNameFromFullName(string s)
         {
            string[] arrstr =  s.Split(' ');

            return arrstr[0];
         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DateSelected"></param>
        /// <returns>String: Only the First Name</returns>
        public static string DeterimineCorrectSuffixForDate(string DateSelected)
        {
            if (DateSelected == "1" || DateSelected == "21" || DateSelected == "31")
            {
                DateSelected += "st";
            }
            else if (DateSelected == "2" || DateSelected == "22")
            {
                DateSelected += "nd";
            }
            else if (DateSelected == "3" || DateSelected == "23")
            {
                DateSelected += "rd";
            }
            else
            {
                DateSelected += "th";
            }
            return DateSelected;
        }

        public static string GenerateSessionID(string ip, DateTime dateTime)
        {
            //IP-sessioncode-randomcode-timestamp
            //41.13.198.185-00-2345assd-1650096005

            return "";
        }

        //32401 - > 0032401
        public static string PrefixPadding(string numberToPad,int limit)
        {
            var paddingNumber = 0;
            if(numberToPad.Length >= 6 )
            {
                return numberToPad;
            }
            string paddednumber = "";
            
            int count = numberToPad.Length;

            if (numberToPad.Length == 4)
            {
                paddednumber += "90";
            }
            if (numberToPad.Length == 5)
            {
                paddednumber += "0";
                
            }

            return (paddednumber+numberToPad).Trim();
        }

        public static string ConvertEnumToString(Genders value)
        {
            switch (value)
            {
                
            }
            return value.ToString();
        }
        
    }
}
