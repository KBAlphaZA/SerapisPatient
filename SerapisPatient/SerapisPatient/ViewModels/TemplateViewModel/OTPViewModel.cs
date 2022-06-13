using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.Models.Entities;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services.DB;
using SerapisPatient.TemplateViews;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.MainViews;
using System;
using System.Diagnostics;
using System.Linq;
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
            var popUp = new DefaultLoadingView();
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                popUp.IsLightDismissEnabled = false;
            }
            RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
            try
            {
                
                App.Current.MainPage.Navigation.ShowPopup(popUp);


                var cachedOtp =(string) App.SessionCache.CacheData[CacheKeys.Otp.ToString()];
                
                if (cachedOtp is null)
                {
                   
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Something went wrong.."));
                    userDb.ClearDatabase();
                    if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                        popUp.Dismiss(null);
                    return;
                }
                if (string.Equals(cachedOtp, OTP))
                {
                    userDb.RetrieveDocument();
                    App.SessionCache.CacheData.Add(CacheKeys.PatientUser.ToString(), userDb);
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully Logged in"));
                    if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                        popUp.Dismiss(null);
                    App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
                else
                {
                    userDb.ClearDatabase();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OTPViewModel: " + ex);
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Something went wrong.."));
                userDb.ClearDatabase();
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
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
