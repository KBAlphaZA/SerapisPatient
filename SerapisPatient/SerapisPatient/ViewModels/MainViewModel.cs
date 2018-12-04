using SerapisPatient.Models;
using SerapisPatient.Models.Doctor;
using SerapisPatient.TabbedPages;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //public ICommand SettingsCommand => new Command(async () => await SettingsAsync());
        public Command NavigateToProfilePageCommand { get; set; }
        public Command NavigateToAppointmentPageCommand { get; set; }
        public Command NavigateToDeliveryPageCommand { get; set; }
        public Command NavigateToCameraPageCommand { get; set; }
        public ObservableCollection<NotificationModel> Notifications { get; private set; }

        public MainViewModel()
        {
            GenerateNotificationList();
            NavigateToProfilePageCommand = new Command(ProfilePage);
            NavigateToAppointmentPageCommand = new Command(AppointmentPage);
            NavigateToDeliveryPageCommand = new Command(DeliveryPage);
            NavigateToCameraPageCommand = new Command(CameraPage);
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
            await App.Current.MainPage.Navigation.PushAsync(new AppointmentPage());
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
    }
}
