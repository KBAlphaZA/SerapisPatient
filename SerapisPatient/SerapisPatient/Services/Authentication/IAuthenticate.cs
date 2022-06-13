using Xamarin.Auth;

namespace SerapisPatient.Services.Authentication
{
     public interface IAuthenticate
    {
         void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e);

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e);

        void OnLoginClicked();
    }
}
