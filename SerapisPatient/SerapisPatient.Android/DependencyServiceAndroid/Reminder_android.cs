using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SerapisPatient.Droid.DependencyServiceAndroid;
using SerapisPatient.Services.DependencyServices;
using Xamarin.Forms;

[assembly:Dependency(typeof(Reminder_android))]
namespace SerapisPatient.Droid.DependencyServiceAndroid
{
    public class Reminder_android : IMedicationReminder
    {
        public void SetReminder(string medicationInstructions, string medicationDosage)
        {
            throw new NotImplementedException();
        }
    }
}