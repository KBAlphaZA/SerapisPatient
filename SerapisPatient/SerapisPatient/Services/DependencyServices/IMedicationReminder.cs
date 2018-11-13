using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Services.DependencyServices
{
    public interface IMedicationReminder
    {
        void SetReminder(string medicationInstructions, string medicationDosage);
    }
}
