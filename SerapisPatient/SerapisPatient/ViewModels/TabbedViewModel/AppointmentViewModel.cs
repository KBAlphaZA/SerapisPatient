using SerapisPatient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TabbedPageViewModel
{
    public class AppointmentViewModel
    {
        public Command BookByDate { get; set; }

        public Command SerapisBooking { get; set; }

        public AppointmentViewModel()
        {
            BookByDate = new Command(NavigateToBookByDate);
            SerapisBooking = new Command(NavigateToSerapisBooking);
        }


        private void NavigateToBookByDate()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new Specilization());
        }

        private void NavigateToSerapisBooking()
        {
             App.Current.MainPage.Navigation.PushModalAsync(new Specilization());
        }

    }
}
