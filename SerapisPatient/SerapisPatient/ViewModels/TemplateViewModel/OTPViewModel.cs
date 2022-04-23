using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.PopUpMessages;
using SerapisPatient.TemplateViews;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TemplateViewModel
{
    public class OTPViewModel : BaseViewModel
    {
        private string otp;
        public string OTP
        {
            get { return otp; }
            set
            {
                otp = value;
                OnPropertyChanged("OTP");
            }
        }
        public ICommand SubmitCommand { get; set; }

        public OTPViewModel()
        {
            SubmitCommand = new Command(ValidateOTP);
        }
        private async void ValidateOTP()
        {
            var popUp = new DefaultLoadingView()
            {
                IsLightDismissEnabled = false,
            };

            try
            {
                
                App.Current.MainPage.Navigation.ShowPopup(popUp);


                var cachedOtp =(string) App.SessionCache.CacheData[CacheKeys.Otp.ToString()];

                if (cachedOtp is null)
                {
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Something went wrong.."));
                    popUp.Dismiss(null);
                    return;
                }
                if (string.Equals(cachedOtp, OTP))
                {
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully Logged in"));
                    popUp.Dismiss(null);
                    App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                    await App.Current.MainPage.Navigation.PopToRootAsync();


                    WriteToDb();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OTPViewModel: " + ex);
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Something went wrong.."));
                popUp.Dismiss(null);
                return;
            }
        }

        private void WriteToDb()
        {
            throw new NotImplementedException();
        }
    }
}
