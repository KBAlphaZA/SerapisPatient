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
        #region Properties
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
        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private readonly IGoogleClientManager _googleClientManager;
        
        //New Google Auth
        #endregion
        public LoginViewModel()
        {
            //GoogleLogin
            
            //Custom Login
            LoginOnClick = new Command(LoginRequestAsync);
            RestThePassword = new Command(RestPassword);
            RegisterOnClick = new Command(RegisterUser);

            

            IsLoggedIn = false;
        }

        /// <summary>
        ///  <c a="LoginAsync"/>
        /// Below is the Authentication Code using Plugin.google
        /// </summary>
        
        #region Methods
        /// <summary>
        /// <c a="RegisterUser"/>
        /// Custom Registeration
        /// </summary>
        private void RegisterUser()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        public ICommand RegisterOnClick { get; set; }
        public ICommand LoginOnClick { get; set; }
        public ICommand RestThePassword { get; set; }

       
        private void LoginRequestAsync()
        {

             HandleAuth();
        }
        /// <summary>
        /// <c a="HandleAuth"/>
        /// This handles the Navigation process, Removing the LoginView from thr stack and replacing it with the homepage/MasterView
        /// 
        /// </summary>
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
        #endregion
    }
}
