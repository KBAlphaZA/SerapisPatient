using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Helpers;
using SerapisPatient.Models.Patient;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services.Data;
using SerapisPatient.TemplateViews;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }


        private string firstNameForm;
        public string FirstNameForm
        {
            get { return firstNameForm; }
            set {
                firstNameForm = value;
                OnPropertyChanged("FirstNameForm");
            }
        }

        private string lastNameForm;
        public string LastNameForm
        {
            get { return lastNameForm; }
            set
            {
                lastNameForm = value;
                OnPropertyChanged("LastNameForm");
            }
        }

        private string cellphoneNumberForm;
        public string CellphoneNumberForm
        {
            get { return cellphoneNumberForm; }
            set
            {
                cellphoneNumberForm = value;
                OnPropertyChanged("CellphoneNumberForm");
            }
        }

        private string pinForm;
        public string PinForm
        {
            get { return pinForm; }
            set
            {
                pinForm = value;
                OnPropertyChanged("PinForm");
            }
        }

        public delegate void DismissPopUpDelegate();
        public delegate void ExpandPopUpDelegate();
        public DismissPopUpDelegate OnDismissPopup { get; set; }
        public ExpandPopUpDelegate OnExpandPopup { get; set; }

        public ICommand RegisterCommand { get; set; }

        #endregion
        public RegisterViewModel()
        {
            RegisterCommand = new Command(ExcecuteRegistration);
        }

        private async void ExcecuteRegistration(object obj)
        {
            Debug.WriteLine("Password: " + obj);
            var current = Xamarin.Essentials.Connectivity.NetworkAccess;
            if(current == Xamarin.Essentials.NetworkAccess.Internet)
            {
                await RegisterUser();
                return;
            }
            await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "There is no Internet.."));
            await App.Current.MainPage.Navigation.PopAsync();
            return;
        }

        private async Task RegisterUser()
        {
            var popUp = new DefaultLoadingView()
            {
                IsLightDismissEnabled = false,
            };            
            try
            {
                //base.IsBusy = true;
               
                App.Current.MainPage.Navigation.ShowPopup(popUp) ;
                Debug.WriteLine("Password: *************");
                var internationalNumber = NumberUtil.ReplaceFirst(CellphoneNumberForm, "0", "27");
                Patient form = new Patient
                {
                    PatientFirstName = FirstNameForm,
                    PatientLastName = LastNameForm,
                    PatientContactDetails = new Models.PatientContact
                    {
                        CellphoneNumber = internationalNumber,
                    },
                    Token = StringUtil.PrefixPadding(PinForm, 6)   
                };

                IsBusy = true;
                var response = await AuthenticationService.RegisterUserViaSupabaseAsync(form);
                Debug.WriteLine(response?.status);
                Debug.WriteLine(response?.message);
                popUp.Dismiss(null);
                if (!response.status)
                {
                    if (response.StatusCode == StatusCodes.AuthenticonError && response.message.Contains("already"))
                    {
                        await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "You already registered with Serapis Medical.."));
                        return;
                    }

                    //{ "code":422,"msg":"Signup requires a valid password"}
                    if (response.message.Contains("{ \"code\":422,\"msg\":\"Signup requires a valid password\"}"))
                    {
                        await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "You already registered with Serapis Medical.."));
                        return;
                    }
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Something went wrong.."));
                    return;
                }


                var rootpage = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault();
                if (rootpage != null)
                {
                    //App.CheckLogin = true;
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully Registered"));
                    App.Current.MainPage.Navigation.InsertPageBefore(new LoginViewV2(), App.Current.MainPage.Navigation.NavigationStack.First());

                    // await Task.Delay(600);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
                
            }
                    
            catch (Exception e)
            {
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    popUp.Dismiss(null);
                
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Something went wrong.."));
                Debug.WriteLine("Error: "+e);
                return;
            }
            finally
            {
                IsBusy = false;
            }

            
        }
    }
}
