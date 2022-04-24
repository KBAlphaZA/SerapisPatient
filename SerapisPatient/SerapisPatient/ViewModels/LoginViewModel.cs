using SerapisPatient.Models;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.MainViews;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SerapisPatient.Models.Patient;
using Realms;
using MongoDB.Bson;
using SerapisPatient.Services.Authentication;
using SerapisPatient.Helpers.Validations;
using SerapisPatient.Helpers.Validations.Rules;
using SerapisPatient.TemplateViews;
using Xamarin.CommunityToolkit.Extensions;
using SerapisPatient.Services.Data;
using SerapisPatient.Utils;
using SerapisPatient.Models.Patient.Supabase;
using SerapisPatient.PopUpMessages;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.Services.DB;
using SerapisPatient.Models.Entities;

namespace SerapisPatient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticate _authenticate;
        GoogleAuthentication googleAuthentication = new GoogleAuthentication();

        #region Properties

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
        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }

        public ValidatableObject<string> CellNumber { get; set; }
        public ValidatableObject<string> Password { get; set; }

        public ICommand ValidateCommand { get; set; }

        public ICommand LoginOnClick { get; set; }
        public ICommand RestThePassword { get; set; }
        public ICommand NavigateToRegisterViewCommand { get; set; }

    
        public bool IsNotBusy { get { return !IsBusy; } }
        public Patient _patient { get; set; }

        public Command OnLoginCommand { get; set; }
     
        #endregion
        public LoginViewModel()
        {
            LoginViewModelInit();


        }

        public void LoginViewModelInit()
        {
            OnLoginCommand = new Command( () => GoogleLogin());
            ValidateCommand = new Command<string>(ValidateCommandHandler);


            //Custom Login
            LoginOnClick = new Command(LocalAuthAsync);
            NavigateToRegisterViewCommand = new Command(NavigateRegister);
            //LoginOnClick = new Command(() => Task.Run(HandleAuth));
            AddValidations();
            IsLoggedIn = false;
        }

        private async void NavigateRegister()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        private async void LocalAuthAsync(object obj)
        {
            await HandleAuth();
        }
        #region Methods

        private void ValidateCommandHandler(string field)
        {
            switch (field)
            {
                case "name": CellNumber.Validate(); break;
                case "password": Password.Validate(); break;
            }
        }
        public void Logout()
        {
            RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
            userDb.ClearDatabase();
            userDb.Dispose();
        }

        public void GoogleLogin()
        {
            
            googleAuthentication.OnLoginClicked();
        }


        /// <summary>
        /// <c a="HandleAuth"/>
        /// This handles the Navigation process, Removing the LoginView from thr stack and replacing it with the homepage/MasterView
        /// 
        /// </summary>
        private async Task HandleAuth()
        {
            var popUp = new DefaultLoadingView()
            {
                IsLightDismissEnabled = false,
            };
            try
            {
                App.Current.MainPage.Navigation.ShowPopup(popUp);
                var internationalNumber = NumberUtil.ReplaceFirst(CellphoneNumberForm, "0", "27");
                var user = new SupabaseAuth
                {
                    phone = internationalNumber,
                    password = StringUtil.PrefixPadding(PinForm, 5)
                };

                var response = await AuthenticationService.LoginUserViaSupabaseAsync(user);

                Debug.WriteLine(response?.status);
                Debug.WriteLine(response?.message);
                if (!response.status)
                {
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "You already registered with Serapis Medical.."));
                    return;

                }
                bool otpEnabled = true;
                if (!otpEnabled)
                {
                    App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                
                RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
                using (userDb)
                {
                    await userDb.SaveDocumentAsync(new PatientDao
                    {
                        id = response.data.PatientData.id,
                        AuthId = response.data.PatientData.SocialID,
                        PatientFirstName = response.data.PatientData.PatientFirstName,
                        PatientLastName = response.data.PatientData.PatientLastName,
                        MedicalAidPatient = response.data.PatientData.MedicalAidPatient,
                        PatientBloodType = response.data.PatientData.PatientBloodType,
                        PatientAge = response.data.PatientData.PatientAge,
                        PatientProfilePicture = response.data.PatientData.PatientProfilePicture,
                        BirthDate = response.data.PatientData.BirthDate,
                        IsAuthenticated = true,
                        AuthenticationExpiresIn = response.data.SupabaseData.ExpiresAt().ToString(),
                        RefreshToken = response.data.SupabaseData.RefreshToken,

                    });
                }
                
                App.SessionCache.CacheData.Add(CacheKeys.SessionUser.ToString(), response.data);
                App.SessionCache.CacheData.Add(CacheKeys.Otp.ToString(), response.data.Otp);
                await App.Current.MainPage.Navigation.PushAsync(new OtpView());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                popUp.Dismiss(null);
            }
        }

        private void AddValidations()
        {
            CellNumber = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

      
            CellNumber.Validations.Add(new IsCellNumberRule<string> { ValidationMessage = "Cell Number format is not correct" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

        #endregion
    }
}
