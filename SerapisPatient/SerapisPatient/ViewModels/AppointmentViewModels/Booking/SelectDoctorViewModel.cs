using SerapisPatient.behavious;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.Practices;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels.Booking
{
        //DEPRICIATED. TO BE DELETED
    public class SelectDoctorViewModel : BaseViewModel
    {
        #region Properties
        public Doctor enquiredDoctor;
        public PracticeDto _medicalBuildingData;
        public ObservableCollection<Doctor> Doctors { get; set; }
        string FullDateAndMonth;
        public ICommand NavigateToConfrimation { get; set; }

        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        #endregion
        public ICommand SelectedCommand => new Command<Doctor>(async selectDoctor =>
        {
        NavigateNextPageRequest.Raise(new SelectedItemEvent { SelectedDoctor = selectDoctor });
             enquiredDoctor = selectDoctor;               
            // MessagingCenter.Send(this, MessagingKeys.Medicalbuilding, doctorname);

            await GoToConfirmation(enquiredDoctor, _medicalBuildingData, FullDateAndMonth);
        });


        //Important
        public SelectDoctorViewModel(MedicalBuildingModel _MedicalBuildingData)
        {
            //GenerateDoctorList();
            // NavigateToConfrimation = new Command(async () => await GoToConfirmation());
        }

       

        private async Task GoToConfirmation(Doctor enquiredDoctor, PracticeDto _medicalBuildingData, string FullDateAndMonth )
        {
            //This sends the message of itemSelected       
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmBooking(enquiredDoctor, _medicalBuildingData, FullDateAndMonth), true);
        }
    }
}
