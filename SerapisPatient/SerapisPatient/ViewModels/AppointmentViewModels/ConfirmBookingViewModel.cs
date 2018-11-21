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
using SerapisPatient.ViewModels.AppointmentViewModels.Booking;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{
    public class ConfirmBookingViewModel : BaseViewModel
    {
        #region Global Declarations
        public Command NavigateToHomePageCommand { get; set; }
       
        #endregion

        public ConfirmBookingViewModel()
        {
            MessagingCenter.Subscribe<SelectDoctorViewModel, string>(this, MessagingKeys.Doctor, (sender, args) =>
            {
                string Surname = args.ToString();
                // NameOfPractice = args;
            });

            NavigateToHomePageCommand = new Command(ConfirmBooking);    
        }

        #region Navigation Tasks

        private void ShowDetails()
        {
           
            
            
        }
        private async void ConfirmBooking()
        {
            // await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, Problem has been occurred while submitting your data."));
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("W", "Warning!, There was a problem with your Network Connection"));
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("N", "Note!, Please read the comments carefully."));

            await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S","You Successfully completed your booking"));
            await Task.Delay(100);
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
