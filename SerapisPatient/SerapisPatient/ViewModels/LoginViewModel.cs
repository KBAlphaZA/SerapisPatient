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
using Plugin.FacebookClient.Abstractions;
using Newtonsoft.Json.Linq;
using SerapisPatient.Services.Data;

namespace SerapisPatient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Properties

        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }

        public ICommand RegisterOnClick { get; set; }
        public ICommand LoginOnClick { get; set; }
        public ICommand RestThePassword { get; set; }

        //FACEBOOK AUTH
        string[] permisions = new string[] { "email", "public_profile", "user_posts" };

        public bool IsBusy { get; set; } = false;
        public bool IsNotBusy { get { return !IsBusy; } }
        public FacebookProfile Profile { get; set; }

        

        public Command OnLoginCommand { get; set; }
        public Command OnShareDataCommand { get; set; }
        public Command OnLoadDataCommand { get; set; }
        public Command OnLogoutCommand { get; set; }
        APIServices services = new APIServices();
        public AuthenticationService authenticationService = new AuthenticationService();
        #endregion
        public LoginViewModel()
        {

            //Facebook Login
            Profile = new FacebookProfile();
            
            OnLoginCommand = new Command(async () => await FacebookLoginAsync());
            OnLoadDataCommand = new Command(async () => await FacebookLoadData());
            OnLogoutCommand = new Command(() =>
            {
                // Add logout method
                
            }); 

            //Custom Login
            //LoginOnClick = new Command(FacebookLoginAsync);
            RestThePassword = new Command(RestPassword);
            //RegisterOnClick = new Command(RegisterUser);

            IsLoggedIn = false;
        }

        #region Methods
        public void Logout()
        {

        }

        /// <summary>
        /// <c a="RegisterUser"/>
        /// Custom Registration
        /// </summary>
        private void RegisterUser()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterView());
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
            await HandleAuth(Profile);

        }
       
        //private void LoginRequestAsync(FacebookProfile profile)
        //{

        //    HandleAuth(profile);
        
        //}

        /// <summary>
        /// <c a="HandleAuth"/>
        /// This handles the Navigation process, Removing the LoginView from thr stack and replacing it with the homepage/MasterView
        /// 
        /// </summary>
        private async Task HandleAuth(FacebookProfile profile)
        {
            IsBusy = true;
            try
            {

                PatientUser suceess = await authenticationService.FacebookLogin(profile);

            }
            catch(Exception ex)
            {

            }
            finally
            {

                App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First() );
                await App.Current.MainPage.Navigation.PopAsync();

                IsBusy = false;

            }

          
        }

        private void RestPassword()
        {
            //for now move on to the main page
            //App.Current.MainPage.Navigation.PushModalAsync(new MasterDetailPage1());
        }

        /// <summary>
        ///  <c a="LoginAsync"/>
        /// Below is the Authentication Code using Plugin.google
        /// </summary>
        
        #endregion
    }
}
