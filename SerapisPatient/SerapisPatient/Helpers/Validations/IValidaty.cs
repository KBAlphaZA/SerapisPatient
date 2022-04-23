using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Helpers.Validations
{
    internal interface IValidaty
    {
        bool IsValid { get; set; }
        bool IsButtonActive { get; set; }
    }
}
