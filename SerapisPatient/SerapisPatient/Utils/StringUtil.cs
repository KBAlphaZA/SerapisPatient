using System;
using System.Collections.Generic;
using System.Text;

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
        /// For Some 3rd party API's we get the first name as a full name or multiple names, so we extract only the first name
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
    }
}
