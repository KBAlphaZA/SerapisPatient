using Plugin.Connectivity;
using SerapisPatient.Services;
using SerapisPatient.Views;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TabbedViewModel
{
    public class DeliveryPageViewModel:NetworkConnectivity
    {
        

        public DeliveryPageViewModel()
        {
            DoctorPrescription = new Command(GetThePrescriptionList);
            ChatBotInitilization = new Command(StartChatBot);
        }

        public Command DoctorPrescription { get; set; }
        public Command ChatBotInitilization { get; set; }

        public bool CheckInternetConnection()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GetThePrescriptionList()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new DoctorPrescriptionView());
        }

        private async void StartChatBot()
        {
            if (CheckInternetConnection() == false)
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new NetworkErrorPage());
                CheckInternetConnection();
            }
            else
            {
                //await App.Current.MainPage.Navigation.PushModalAsync(new ChatBot());
                await App.Current.MainPage.Navigation.PushAsync(new ChatBot());
            }

        }
    }
}
