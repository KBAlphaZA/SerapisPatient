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

namespace SerapisPatient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public UserProfile User { get; set; } = new UserProfile();
        public string Name
        {
            get => User.Name;
            set => User.Name = value;
        }

        public string Email
        {
            get => User.Email;
            set => User.Email = value;
        }

        public Uri Picture
        {
            get => User.Picture;
            set => User.Picture = value;
        }

        public bool IsLoggedIn { get; set; }

        public string Token { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private readonly IGoogleClientManager _googleClientManager;

        public LoginViewModel()
        {
            //GoogleLogin
            LoginCommand = new Command(LoginAsync);

            LoginOnClick = new Command(LoginRequestAsync);
            RestThePassword = new Command(RestPassword);
            RegisterOnClick = new Command(RegisterUser);

            _googleClientManager = CrossGoogleClient.Current;

            IsLoggedIn = false;
        }

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
                GoogleUser googleUser = loginEventArgs.Data;
                User.Name = googleUser.Name;
                User.Email = googleUser.Email;
                User.Picture = googleUser.Picture;
                var GivenName = googleUser.GivenName;
                var FamilyName = googleUser.FamilyName;


                // Log the current User email
                Debug.WriteLine(User.Email);
                IsLoggedIn = true;

                var token = CrossGoogleClient.Current.ActiveToken;
                Token = token;

                App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                App.Current.MainPage.Navigation.PopAsync();

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }

            _googleClientManager.OnLogin -= OnLoginCompleted;

        }
        private void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            IsLoggedIn = false;
            User.Email = "Offline";
            _googleClientManager.OnLogout -= OnLogoutCompleted;
        }
        //end of google code

        public void Logout()
        {
            _googleClientManager.OnLogout += OnLogoutCompleted;
            _googleClientManager.Logout();
        }

        private void RegisterUser()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        public ICommand RegisterOnClick { get; set; }
        public ICommand LoginOnClick { get; set; }
        public ICommand RestThePassword { get; set; }

        //private string email;
        //public string Email
        //{
        //    get
        //    {
        //        return email;
        //    }
        //    set
        //    {
        //        email = value;
        //        OnPropertyChanged("Email");
        //    }
        //}

        //private string password;
        //public string Password
        //{
        //    get
        //    {
        //        return password;
        //    }
        //    set
        //    {
        //        string password = value;
        //        OnPropertyChanged("Password");
        //    }
        //}

        private void LoginRequestAsync()
        {

             HandleAuth();
        }
        private async Task HandleAuth()
        {
            IsBusy = true;
            try
            {
                //App.CheckLogin = true;
                App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());
                await App.Current.MainPage.Navigation.PopAsync();

            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
            }

          
        }

        private void RestPassword()
        {
            //for now move on to the main page
            App.Current.MainPage.Navigation.PushModalAsync(new MasterDetailPage1());
        }

    }
}
