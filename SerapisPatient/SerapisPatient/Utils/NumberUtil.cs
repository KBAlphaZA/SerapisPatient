using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace SerapisPatient.Utils
{
    public static class NumberUtil
    {
        /// <summary>
        /// Converts double/int/string value to a Float value 
        /// </summary>
        /// <param name="value">Pass through a valid Double number</param>
        /// <returns></returns>
        public static float ToSingle(object value)
        {
            if (value is double)
            {
                double doubleVal = (double) value;
                return (float)doubleVal/100;    
            }else if(value is int)
            {
                int intVal = (int) value;
                return (float)intVal/100; 
            }else if (value is string)
            {
                string intVal = (string) value;
                return float.Parse(intVal)/100; 
            }

            return 0f;
        }
        

        public static string GenerateRandomCode(int length)
        {
            var sufficientBufferSizeInBytes = (length * 6 + 7) / 8;
            var buffer = new byte[sufficientBufferSizeInBytes];
            RandomNumberGenerator.Create().GetBytes(buffer);
            var result = Convert.ToBase64String(buffer).Substring(0, length);
            return Regex.Replace(result, "[^A-Za-z0-9]", "");
        }

        // 0817004798 ; 0 ; 27 -> 27817004798
        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            string result = text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
            return result;
        }
    }
}