using System;
using System.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using SerapisPatient.Helpers;

namespace SerapisPatient.Services.Authentication
{
    public class GoogleAuthentication
    {
        //clientid : 146806431671-mc2okbks55i70e532tl90cccdd146sg1.apps.googleusercontent.com
        // clientsecret: L-sms1KEEJhDZKJwkeKAeYos

        /// <summary>
        /// Create a new app and get new creadentials: 
        /// https://console.developers.google.com/apis/
        /// </summary>
        public static readonly string ClientId = "660976645428-r9kcb5cera105cfd60k8cmvuk15fbdlk.apps.googleusercontent.com";
        ///public static readonly string OldClientId = "359654294538-7351kkc5l40mh3r6jncfcb0li2uetndu.apps.googleusercontent.com";
        public static readonly string ClientSecret = "bx0l0C9lhcuF8cF8gfW9h8A7 ";
        public static readonly string RedirectUri = "https://www.youtube.com";


        Account account;
        AccountStore store;
        AccountResult result;

        public GoogleAuthentication()
        {
            store = AccountStore.Create();
            account = store.FindAccountsForService(serviceId: "660976645428-r9kcb5cera105cfd60k8cmvuk15fbdlk.apps.googleusercontent.com").FirstOrDefault();
            
        }

        public void OnLoginClicked()
        {

            const string clientIdConstant = "660976645428-r9kcb5cera105cfd60k8cmvuk15fbdlk.apps.googleusercontent.com";
            string redirectUriConstant = "com.googleusercontent.apps."+clientIdConstant+":/oauth2redirect" ;

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
                     string.Empty,
                     /*"profile"*/
                     ConstantValues.GoogleScope,
                     new Uri("https://accounts.google.com/o/oauth2/auth"),
                     new Uri(ConstantValues.GoogleAndroidRedirectUri),
                     new Uri("https://www.googleapis.com/oauth2/v4/token"),
                     null,
                     true
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

        }

        public async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
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
                // New block of code for Firebase
                
                try
                {
                    var google_provider_authCredential = Plugin.FirebaseAuth.CrossFirebaseAuth.Current.GoogleAuthProvider.GetCredential(e.Account.Properties["id_token"], e.Account.Properties["access_token"]);
                    var result = await Plugin.FirebaseAuth.CrossFirebaseAuth.Current.Instance.SignInWithCredentialAsync(google_provider_authCredential);

                    Debug.WriteLine(result);
                }
                catch (Plugin.FirebaseAuth.FirebaseAuthException ex)
                {
                    Debug.WriteLine(ex.Message);
                    
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

        public void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        public class AuthenticationState
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
