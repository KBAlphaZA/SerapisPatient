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
using Plugin.Connectivity;
using SerapisPatient.Services;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.Practices;
using System.Linq;
using System.Diagnostics;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{
    public class ConfirmBookingViewModel : BaseViewModel
    {
        #region Global Declarations
        public Command NavigateToHomePageCommand { get; set; }
        public Doctor SelectedDoctor { get; set; }
        public PracticeDto SelectedMedicalBuilding { get; set; }
        public DateTime FullDateAndMonth { get; set; }

        public bool BookingSuccess = false;
        public string DateSelected = " ";
        APIServices services = new APIServices();

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

        public ConfirmBookingViewModel(Doctor enquiredDoctor, PracticeDto _medicalBuildingModel, string _FullDateAndMonth)
        {
            // 1) Xamlbindings. 
            // 2) One method to handle all bindings & keep things neat
            XamlBindings(enquiredDoctor, _medicalBuildingModel, _FullDateAndMonth);

            NavigateToHomePageCommand = new Command(ConfirmBooking);
        }

        #region Navigation Tasks

        private void XamlBindings(Doctor enquiredDoctor, PracticeDto _medicalBuildingModel, string _FullDateAndMonth)
        {

            SelectedDoctor = enquiredDoctor;
            SelectedMedicalBuilding = _medicalBuildingModel;

            PracticeName = _medicalBuildingModel.PracticeName;
            LastName = enquiredDoctor.LastName;
            Debug.WriteLine(" Doctor Recieved => [" + enquiredDoctor.ToString()+ "]"+ "MedicalBuildingModel Recieved" + "[" + _medicalBuildingModel + "]"+ "FullDateAndMonth Recieved" + "[" +_FullDateAndMonth+ "]");
            ConvertTimeDate(_FullDateAndMonth);
        }
        private void ConvertTimeDate(string _FullDateAndMonth)
        {
            //converts to DateTime format for Storage purposes
            //FullDateAndMonth = DateTime.Parse(_FullDateAndMonth);
        }

        private async void ConfirmBooking() //this method can pass through an object -Bonga
        {
            await MakeBookingAsync();

            //if the booking fails dont navigate anywhere just notify the user that there was an error
            if (BookingSuccess != true)
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, We couldn't complete your booking. Please Try Again"));

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
                var dbuser = _realm.All<Patient>().FirstOrDefault();
                if (CrossConnectivity.Current.IsConnected)
                {
                    var isSuccess = await services.CreateAppointment(dbuser.id,FullDateAndMonth,SelectedDoctor, SelectedMedicalBuilding);
                }
                else
                {
                    BookingSuccess = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                BookingSuccess = true;
                IsBusy = false;
            }
        }

        #endregion
    }
}
