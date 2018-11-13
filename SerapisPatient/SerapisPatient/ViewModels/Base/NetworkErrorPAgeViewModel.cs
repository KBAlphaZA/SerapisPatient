using Plugin.Connectivity;
using SerapisPatient.Services;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    class NetworkErrorPAgeViewModel:BaseViewModel
    {

        public NetworkErrorPAgeViewModel()
        {
            CommandForRefreash = new Command(RefreashThePage);
        }

        public Command CommandForRefreash { get; set; }

        public void CheckInternetConnection()
        {
            var connectionTest = CrossConnectivity.Current.IsConnected;

            if (connectionTest == false)
            {
                return;
            }
            else
            {
                App.Current.MainPage.Navigation.PopModalAsync();
                App.Current.MainPage.Navigation.PushModalAsync(new ChatBot());
            }
        }

        private async void RefreashThePage()
        {
            IsBusy = true;

            try
            {
                CheckInternetConnection();
            }
            catch(TimeoutException timeout)
            {
               
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
