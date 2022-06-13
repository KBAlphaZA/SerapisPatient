using SerapisPatient.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Rg.Plugins.Popup.Services;

namespace SerapisPatient.ViewModels
{
    public class CameraViewModel
    {

        private DeliveryMedicationPopUp deliveryPage;

        public CameraViewModel()
        {
            IntilizeScanner = new Command(async()=>await ScanCode());
            deliveryPage = new DeliveryMedicationPopUp();
        }

        public Command IntilizeScanner { get; set; }


        private async Task ScanCode()
        {
            var ScannerPage = new ZXingScannerPage();

            try
            {
                await App.Current.MainPage.Navigation.PushModalAsync(ScannerPage);
            }
            catch(Exception ex)
            {
                throw new Exception("Something something {0}",ex);
                //give an error for not scanning the code
            }
            finally
            {
                ScannerPage.OnScanResult += (result) =>
                {

                    ScannerPage.IsEnabled = false;

                    // Alert with customers name
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (result.Text == "http://en.m.wikipedia.org")
                        {
                            await PopupNavigation.PopAllAsync(false);
                            await PopupNavigation.Instance.PushAsync(deliveryPage);
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("it did not match", " ", "Cancel");
                        }
                    });

                };
            }
            
        }

    }
}
