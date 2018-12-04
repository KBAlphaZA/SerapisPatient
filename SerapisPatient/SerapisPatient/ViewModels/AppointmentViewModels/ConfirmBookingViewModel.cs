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
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{
    public class ConfirmBookingViewModel : BaseViewModel
    {
        #region Global Declarations
        public Command NavigateToHomePageCommand { get; set; }
        public bool BookingSuccess = true;
        public string DateSelected = " ";

        private string doctorLastName;
        public string LastName
        {
            get
            {
                return doctorLastName;
            }
            set
            {
                doctorLastName = value;

                RaisePropertyChanged(nameof(LastName));
            }

        }
        private string practiceName;
        private string SelectedMonth;

        public string PracticeName
        {
            get
            {
                return practiceName;
            }
            set
            {
                practiceName = value;

                RaisePropertyChanged(nameof(PracticeName));
            }

        }
        #endregion

        public ConfirmBookingViewModel(Doctor enquiredDoctor, MedicalBuildingModel _medicalBuildingModel)
        {
            PracticeName = _medicalBuildingModel.PracticeName;
            //string var = MonthsSelectedIndex.ToString();
            //DateSelected = var + SelectedDay.MonthValue
            ConfrimData();
            LastName = enquiredDoctor.LastName;
            NavigateToHomePageCommand = new Command(ConfirmBooking);    
        }

        #region Navigation Tasks

       private void ConfrimData()
        {
            MessagingCenter.Subscribe<SelectBookingViewModel, SelectedMonths>(this, "ItemSelected", (obj, item) =>
            {
                  // DateSelected = item.MonthValue.ToString();
            }); 
            

            
        }
        private async void ConfirmBooking()
        {
            // await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, Problem has been occurred while submitting your data."));
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("W", "Warning!, There was a problem with your Network Connection"));
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("N", "Note!, Please read the comments carefully."));
            if(BookingSuccess !=true)
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, Problem has been occurred while submitting your data."));
            else
            {
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully completed your booking"));
                await Task.Delay(100);
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
            
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
