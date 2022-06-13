using Realms;
using SerapisPatient.Views.MainViews;
using System;
using System.Linq;
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

        public ICommand RegisterOnClick { get; set; }
        public ICommand LoginOnClick { get; set; }
        public ICommand RestThePassword { get; set; }

        public Command OnLoginCommand { get; set; }
        public Command OnShareDataCommand { get; set; }
        public Command OnLoadDataCommand { get; set; }
        public Command OnLogoutCommand { get; set; }
        #endregion
        
       

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
