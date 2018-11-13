using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace SerapisPatient.Services.Authentication
{
    public class FacebookAuthentication
    {
        Account account;
        AccountStore store;

        const string clientConst = "";
        const string redirectConst = "";

        public FacebookAuthentication()
        {
            store = AccountStore.Create();
            account = store.FindAccountsForService(serviceId: "136133043698809").FirstOrDefault();
        }

        public void OnLoginClicked()
        {
            string client = null;
            string redirectUri = null;

            

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    client = clientConst;
                    redirectUri = redirectConst;
                    break;

                case Device.Android:
                    client = clientConst;
                    redirectUri = redirectConst;
                    break;

                case Device.UWP:
                    client = clientConst;
                    redirectUri = redirectConst;
                    break;

            }

            OAuth2Authenticator authenticator = new OAuth2Authenticator
                (
                    clientConst,
                    null,
                    "public_profile",
                    new Uri("https://m.facbook"),
                    new Uri("https://redirect"),
                    new Uri("https://redirect"),
                    null,
                    true
                );

            authenticator.Completed+= OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl =
                var request = new OAuth2Request("GET", new Uri("http://projectpanda.azurewebsites.net"), null, e.Account);
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
                    store.Delete(account, serviceId: clientConst);
                }

                await store.SaveAsync(account = e.Account, serviceId: clientConst);
                await DisplayAlert("Email address", "Facebook", cancel: "OK");
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

    }
}
