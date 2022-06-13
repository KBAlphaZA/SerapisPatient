using SerapisPatient.Views.SideMenuPages.SettingsSubFolder;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SideMenuViewModel
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            PersonalButtonCommand = new Command(NavigateToPersonalSettings);
            AppointmentButtonCommand = new Command(NavigateToAppointmentSettings);
            DeliverySettingsCommand = new Command(NavigateToDEliverySettings);
        }

        #region Properties
        public Command PersonalButtonCommand { get; set; }
        public Command AppointmentButtonCommand { get; set; }
        public Command DeliverySettingsCommand { get; set; }
        #endregion

        #region Methods
        private async  void NavigateToPersonalSettings()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PersonalSettings());
        }

        private async void NavigateToAppointmentSettings()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AppointmentSettings());
        }

        private async void NavigateToDEliverySettings()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DeliverySettings());
        }
        #endregion
    }
}
