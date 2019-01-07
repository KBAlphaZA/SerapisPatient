using SerapisPatient.Models;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Services.LocationServices;
using SerapisPatient.TabbedPages;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.MainViews;
using SerapisPatient.Views.NotificationViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        //The Title of the Page
        private readonly string _title = "Serapis Patient";

        //public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public Command NavigateToProfilePageCommand { get; set; }
        public Command NavigateToAppointmentPageCommand { get; set; }
        public Command NavigateToDeliveryPageCommand { get; set; }
        public Command NavigateToCameraPageCommand { get; set; }
        public ObservableCollection<NotificationModel> Notifications { get; private set; }

        //The instance for getting the user location
        UserCurrentLocation usersLocation;

        private NotificationModel selectedCard;
        public NotificationModel SelectedCard
        {
            get => selectedCard;
            set
            {
                SetProperty(ref selectedCard, value);

                MedicationDelvery(SelectedCard);
            }
        }



        public MainViewModel()
        {
            
            GenerateNotificationList();
            NavigateToProfilePageCommand = new Command(ProfilePage);
            NavigateToAppointmentPageCommand = new Command(AppointmentPage);
            NavigateToDeliveryPageCommand = new Command(DeliveryPage);
            NavigateToCameraPageCommand = new Command(CameraPage);

            Title = _title;
        }

        //ListView
        private void GenerateNotificationList()
        {
            Notifications = new ObservableCollection<NotificationModel>
                  {
                    new NotificationModel{ Title = "FOLLOW UP", Body ="You have a follow up with Dr. Duma ", Type="FollowUp" },
                     new NotificationModel{ Title = "MEDICATION DELIVERY", Body ="Your ordered medication should be with you in a few hours ", Type="Delivery" },
                      new NotificationModel{ Title = "DELVIERED", Body =" View your reciept below" },


                  };
        }

        private async void ProfilePage()
        {
            
            //var Profile_navigation = new NavigationPage(new MainView());
            //await App.Current.MainPage.Navigation.PushAsync(Profile_navigation);
            await App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        }

        private async void AppointmentPage()
        {
            //var Appointment_navigation = new  NavigationPage( new AppointmentPage());

            //Busy status
            IsBusy = true;

            try
            {
                #region Getting user location code

                //Get the users location before moving on to the next page
                usersLocation = new UserCurrentLocation();


                await usersLocation.GetCurrentLocationAsync();
                #endregion
            }
            catch (Exception ex)
            {
                Debug.Write("Failed to get user location: "+  ex.Data);
            }
            finally
            {
                //Navigate to the next page

                IsBusy = false;

                await App.Current.MainPage.Navigation.PushAsync(new AppointmentPage());
            }

        }
        private async void DeliveryPage()
        {
           // var Delivery_navigation = new NavigationPage(new AppointmentPage());
            await App.Current.MainPage.Navigation.PushAsync(new DeliveryPage());
        }
        private async void CameraPage()
        {
            //var Camera_navigation = new NavigationPage(new AppointmentPage());
            await App.Current.MainPage.Navigation.PushAsync(new CameraPage());
        }

        private async void TakeMedication()
        {            
            //await App.Current.MainPage.Navigation.PushAsync();
        }

        private async void FollowUp()
        {           
            await App.Current.MainPage.Navigation.PushAsync(new CameraPage());
        }

        private async void MedicationDelvery(NotificationModel _SelectedCard)
        {
            if(bool.Equals(_SelectedCard.Title," "))
            {

            }
            else if(bool.Equals(_SelectedCard.Title, " "))
            {

            }
            else if(bool.Equals(_SelectedCard.Title, "MEDICATION DELIVERY"))
            {
                await App.Current.MainPage.Navigation.PushAsync(new MedicationNotificatonView());
            }
            
        }
       
    }
}
