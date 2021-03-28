using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Utils
{
    public class StringUtil
    {

        public StringUtil()
        {
                
        }
         /// <summary>
         /// For Some 3rd party API's we get the first name as a full name or multiple names, so we extract only the first name
         /// </summary>
         /// <param name="s"></param>
         /// <returns>String: Only the First Name</returns>
         public string ExtractFirstNameFromFullName(string s)
        {
            string[] arrstr =  s.Split(' ');

            return arrstr[0];
        }
    }
}
