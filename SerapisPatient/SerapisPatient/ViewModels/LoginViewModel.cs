using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            RestThePassword = new Command(RestPassword);
        }

        public ICommand RestThePassword { get; set; }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                string password = value;
                OnPropertyChanged("Password");
            }
        }


        private void LoginOnClick(string username, string userPassword)
        {
            username = Email;
            userPassword = Password;

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userPassword))
            {

            }
            else
            {

            }

        }

        private void RestPassword()
        {
            //for now move on to the main page
            App.Current.MainPage.Navigation.PushModalAsync(new MasterDetailPage1());
        }

    }
}
