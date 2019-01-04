using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SerapisPatient.Services
{
    public class GoogleAuthentication
    {
        //clientid : 146806431671-mc2okbks55i70e532tl90cccdd146sg1.apps.googleusercontent.com
        // clientsecret: L-sms1KEEJhDZKJwkeKAeYos



                Account account;
        AccountStore store;
        AccountResult result;

        public GoogleAuthentication()
        {
            store = AccountStore.Create();
            account = store.FindAccountsForService(serviceId: "655782672996 - f7n91tloeocgksh8dogfuijhpfcre2m1.apps.googleusercontent.com").FirstOrDefault();
            
        }

        public void OnLoginClicked()
        {

            const string clientIdConstant = "655782672996-f7n91tloeocgksh8dogfuijhpfcre2m1.apps.googleusercontent.com";
            const string redirectUriConstant = "";

            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = clientIdConstant;
                    redirectUri = redirectUriConstant;
                    break;

                case Device.Android:
                    clientId = clientIdConstant;
                    redirectUri = redirectUriConstant;
                    break;

                case Device.UWP:
                    clientId = clientIdConstant;
                    redirectUri = redirectUriConstant;
                    break;

            }


            OAuth2Authenticator authenticator = new OAuth2Authenticator
                (
                     clientIdConstant,
                     null,
                     "profile",
                     new Uri("https://accounts.google.com/o/oauth2/auth"),
                     new Uri("https://Something.net"),
                     new Uri("https://Something.net"),
                     null,
                     true
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if(authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }


            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri("https://www.googleapis.com/oauth2/v2/userinfo"), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, serviceId: "655782672996-f7n91tloeocgksh8dogfuijhpfcre2m1.apps.googleusercontent.com");
                }

                await store.SaveAsync(account = e.Account, serviceId: "655782672996-f7n91tloeocgksh8dogfuijhpfcre2m1.apps.googleusercontent.com");
                await DisplayAlert("Email address", "Google", cancel: "OK");
            }



        }

        private Task DisplayAlert(string v1, string v2, string cancel)
        {
            throw new NotImplementedException();
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        private class AuthenticationState
        {
            public static OAuth2Authenticator Authenticator { get; internal set; }
        }

        private class User
        {
            internal string ToString(string v, string cancel)
            {
                throw new NotImplementedException();
            }
        }


        public bool CheckToken(string token)
        {
            if (token == result.Token)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
