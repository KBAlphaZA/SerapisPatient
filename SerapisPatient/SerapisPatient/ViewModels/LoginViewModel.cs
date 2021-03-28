using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using SerapisPatient.Models;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using SerapisPatient.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SerapisPatient.Services;
using Plugin.FacebookClient;
using Newtonsoft.Json.Linq;
using SerapisPatient.Services.Data;
using SerapisPatient.Models.Patient;
using Realms;
using SerapisPatient.Services.DB;
using MongoDB.Bson;

namespace SerapisPatient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Properties

        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }


        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        //GOOGLE
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private readonly IGoogleClientManager _googleClientManager;

        public ICommand RegisterOnClick { get; set; }
        public ICommand LoginOnClick { get; set; }
        public ICommand RestThePassword { get; set; }

        //FACEBOOK AUTH
        string[] permisions = new string[] { "email", "public_profile", "user_posts" };
        
        public bool IsNotBusy { get { return !IsBusy; } }
        public FacebookProfile Profile { get; set; }
        public Patient _patient { get; set; }
        public Realm _realm;
        GoogleUser googleUser;

        public Command OnLoginCommand { get; set; }
        public Command OnShareDataCommand { get; set; }
        public Command OnLoadDataCommand { get; set; }
        public Command OnLogoutCommand { get; set; }
        public AuthenticationService authenticationService = new AuthenticationService();
        #endregion
        public LoginViewModel()
        {
            LoginViewModelInit();
            _googleClientManager = CrossGoogleClient.Current;


        }

        public void LoginViewModelInit()
        {
            _realm = Realm.GetInstance();
            //Facebook Login
            Profile = new FacebookProfile();

            _realm.Write(() =>
            {
                // Remove the instance from the realm.
                _realm.RemoveAll();
                // Discard the reference.
            });
            OnLoginCommand = new Command(async () => await FacebookLoginAsync());
            OnLoadDataCommand = new Command(async () => await FacebookLoadData());
            OnLogoutCommand = new Command(() =>
            {

                // Add logout method

            });

            //GOOGLE
            LoginCommand = new Command(LoginAsync);
            
            //Custom Login
            LoginOnClick = new Command(LocalAuth);

            //RestThePassword = new Command(RestPassword);
            RegisterOnClick = new Command(RegisterUser);

            IsLoggedIn = false;
        }
        #region Methods
        public void Logout()
        {
            _realm.Write(() =>
            {
                // Remove the instance from the realm.
                _realm.RemoveAll();
                // Discard the reference.
            });
        }

        /// <summary>
        /// <c a="RegisterUser"/>
        /// Custom Registration
        /// </summary>
        private void RegisterUser()
        {
            //App.Current.MainPage.Navigation.PushAsync(new RegisterView());
            var dbuser = _realm.All<Patient>().FirstOrDefault();
            Debug.WriteLine("DB USER =>" + dbuser.ToJson());

        }
        public async Task FacebookLoginAsync()
        {
            FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(permisions);
            switch (response.Status)
            {
                case FacebookActionStatus.Completed:
                    IsLoggedIn = true;
                    OnLoadDataCommand.Execute(null);
                    break;
                case FacebookActionStatus.Canceled:

                    break;
                case FacebookActionStatus.Unauthorized:
                    await App.Current.MainPage.DisplayAlert("Unauthorized", response.Message, "Ok");
                    break;
                case FacebookActionStatus.Error:
                    await App.Current.MainPage.DisplayAlert("Error", response.Message, "Ok");
                    break;
            }

        }


        public async Task FacebookLoadData()
        {

            var jsonData = await CrossFacebookClient.Current.RequestUserDataAsync
            (
                  new string[] { "id", "name", "email", "picture", "cover", "friends" }, new string[] { }
            );

            var data = JObject.Parse(jsonData.Data);
            Profile = new FacebookProfile()
            {
                ID = data["id"].ToString(),
                FullName = data["name"].ToString(),
                Picture = new UriImageSource { Uri = new Uri($"{data["picture"]["data"]["url"]}") },
                Email = data["email"].ToString()
            };

            //login || Register the user
            //var model = await authenticationService.FacebookLogin(Profile);
            //await HandleAuth();

        }


        // GOOGLE
        public async void LoginAsync()
        {
            _googleClientManager.OnLogin += OnLoginCompleted;
            try
            {
                await _googleClientManager.LoginAsync();
            }
            catch (GoogleClientSignInNetworkErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInCanceledErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInvalidAccountErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInternalErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientNotInitializedErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientBaseException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }

        }

        private void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            
            if (loginEventArgs.Data != null)
            {
                googleUser = loginEventArgs.Data;
                var _ = CrossGoogleClient.Current.ActiveToken;
                string token = "";

                // Log the current User email
                Debug.WriteLine("GOOGLE USER=> "+googleUser.ToJson());
                IsLoggedIn = true;

                Token = token;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }

            //var patientuser = authenticationService.GoogleLogin(googleUser, token);
            _googleClientManager.OnLogin -= OnLoginCompleted;
            HandleAuth(googleUser);
        }
        private void DoDBTransaction(Patient _patient)
        {
            _realm.Write(() =>
            {
                _realm.Add(new Patient
                {
                    PatientFirstName = _patient.PatientFirstName,
                    PatientLastName = _patient.PatientLastName,
                    PatientProfilePicture = _patient.PatientProfilePicture,
                    IsGoogle = true
                });
            });
        }
        private void DoGoogleDBTransaction(GoogleUser _patient)
        {
            _realm.Write(() =>
            {
                _realm.Add(new Patient
                {
                    id = _patient.Id,
                    PatientFirstName = _patient.Name,
                    PatientLastName = _patient.FamilyName,
                    PatientProfilePicture = _patient.Picture.ToString(),
                    IsGoogle = true
                });
            });
        }

        /// <summary>
        /// <c a="HandleAuth"/>
        /// This handles the Navigation process, Removing the LoginView from thr stack and replacing it with the homepage/MasterView
        /// 
        /// </summary>
        private async Task HandleAuth(GoogleUser googleUser)
        {
            IsBusy = true;
            try
            {

                _patient = await authenticationService.GoogleLogin(googleUser, "TOKEN");
                //DoDBTransaction(_patient);
                googleUser.Id = _patient.id;
                DoGoogleDBTransaction(googleUser);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsBusy = false;
                //MessagingCenter.Send(this, "", _patient.id);
                App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First() );
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async void LocalAuth()
        {

            try
            {
                
                //object user = await authenticationService.LoginAsync(Email, Password);
                Patient user = null;
                if(user != null)
                {
                   
                    App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                //dBService.SaveDocument(user);
                /*_realm.Write(() =>
                {
                    _realm.Add(new Patient
                    {
                        id = ObjectId.GenerateNewId(),
                        PatientFirstName = "Bonga"
                    });
                });*/

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        /// <summary>
        ///  <c a="LoginAsync"/>
        /// Below is the Authentication Code using Plugin.google
        /// </summary>
        
        #endregion
    }
}
