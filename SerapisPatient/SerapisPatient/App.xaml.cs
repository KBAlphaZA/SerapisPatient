using SerapisPatient.Services;
using SerapisPatient.Services.Authentication;
using SerapisPatient.TabbedPages;
using SerapisPatient.Views;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SerapisPatient
{
	public partial class App : Application
	{
        //public static PublicClientApplication AuthenticationClient { get; set; }
        public static string User = "Ceba";
        #region Login services
        GoogleAuthentication googleToken = new GoogleAuthentication();
        FacebookAuthentication facebookToken = new FacebookAuthentication();
        MicrosoftAuthentication microsoftToken = new MicrosoftAuthentication();
        #endregion

        public App ()
		{
			InitializeComponent();
            Init();
        }

        private void Init()
        {
            //check if the user still has a token for login

            var checkTokenvar=CheckLogin(true);

            if (checkTokenvar!=true)
            {
                 MainPage = new NavigationPage(new MainPage());
                
            }
            else
            {
                MainPage = new NavigationPage(new MasterDetailPage1());
               //MainPage = new NavigationPage(new SelectPractice());

            }

        }

        private bool CheckLogin(bool tokenPresent)
        {

            if (tokenPresent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		protected override void OnStart ()
		{
     
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
