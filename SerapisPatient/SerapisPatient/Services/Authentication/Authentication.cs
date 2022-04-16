using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Realms;
using SerapisPatient.Models;
using SerapisPatient.Models.Patient;
using SerapisPatient.Services.Data;
using SerapisPatient.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.Services.Authentication
{
    public class Authentication
    {

        #region Properties
        public bool IsBusy;
        public Realm _realm;
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
        public FacebookProfile Profile { get; set; }
        public Patient _patient { get; set; }
        GoogleUser googleUser;

        public Command OnLoginCommand { get; set; }
        public Command OnShareDataCommand { get; set; }
        public Command OnLoadDataCommand { get; set; }
        public Command OnLogoutCommand { get; set; }
        public AuthenticationService authenticationService = new AuthenticationService();
        #endregion

       [Obsolete("Bonga: This was used for The Google.Plugin, which we wont be using anymore")]
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
        [Obsolete("Bonga: This was used for The Google.Plugin, which we wont be using anymore")]
        private void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {

            if (loginEventArgs.Data != null)
            {
                googleUser = loginEventArgs.Data;
                var _ = CrossGoogleClient.Current.ActiveToken;
                string token = "";

                // Log the current User email
                Debug.WriteLine("GOOGLE USER=> " + googleUser.ToJson());
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
        
        [Obsolete("Bonga: This was used for The Google.Plugin, which we wont be using anymore")]
        private void DoDBTransaction(Patient _patient)
        {
            _realm.Write(() =>
            {
                _realm.Add<Patient>(_patient);
            });
        }
        
        [Obsolete("Bonga: This was used for The Google.Plugin, which we wont be using anymore")]
        private void DoGoogleDBTransaction(GoogleUser _patient)
        {
            /*Realm.Write(() =>
            {
                _realm.Add(new Patient
                {
                    PatientFirstName = _patient.Name,
                    PatientLastName = _patient.FamilyName,
                    PatientProfilePicture = _patient.Picture.ToString(),
                    IsGoogle = true
                });
            });*/
        }
        
        /// <summary>
        /// <c a="HandleAuth"/>
        /// This handles the Navigation process, Removing the LoginView from thr stack and replacing it with the homepage/MasterView
        /// 
        /// </summary>
        [Obsolete("Bonga: This was used for The Google.Plugin, which we wont be using anymore")]
        private async Task HandleAuth(GoogleUser googleUser)
        {
            IsBusy = true;
            try
            {
                _patient = await authenticationService.GoogleLogin(googleUser, "TOKEN");
                _patient.SocialID = googleUser.Id;
                _patient.PatientProfilePicture = googleUser.Picture.ToString();

                //DoGoogleDBTransaction(googleUser);
                DoDBTransaction(_patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsBusy = false;
                //MessagingCenter.Send(this, "", _patient.id);
                App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        [Obsolete("Bonga: This was used for The Google.Plugin, which we wont be using anymore")]
        public async void LocalAuth()
        {

            try
            {

                //object user = await authenticationService.LoginAsync(Email, Password);


                App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                await App.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //IsBusy = false;
            }

        }
        

    }
}
