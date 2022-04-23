using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Helpers.Validations.Rules
{
    class IsCellNumberRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            if (str.Trim().StartsWith("+27"))
            {
                str = str.Substring(3, str.Length-1);
            }
            if (str.Length == 10)
            {
                return true;
            }
            return false;
        }
    }
}
