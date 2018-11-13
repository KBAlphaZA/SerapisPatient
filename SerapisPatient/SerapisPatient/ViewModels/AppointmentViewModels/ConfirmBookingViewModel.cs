using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.BehaviorsPack;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.PopUpMessages;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{
    public class ConfirmBookingViewModel : BaseViewModel
    {
        #region Global Declarations
        public Command NavigateToHomePageCommand { get; set; }
       
        #endregion

        public ConfirmBookingViewModel()
        {
            
            ShowDetails();
            NavigateToHomePageCommand = new Command(ConfirmBooking);
           
        }

        #region Navigation Tasks

        private void ShowDetails()
        {
            MessagingCenter.Subscribe<MedicalBuildingViewModel, string>(this, MessagingKeys.Medicalbuilding, (sender, args) =>
            {

                // NameOfPractice = args;

            });
        }
        private async void ConfirmBooking()
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S","You Successfully completed your booking"));
            await Task.Delay(1500);
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
        #endregion

        #region CloudCode
        private async Task MakeBookingAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {

            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
