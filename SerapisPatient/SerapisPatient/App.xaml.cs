using SerapisPatient.Models;
using SerapisPatient.Services;
using SerapisPatient.Services.Authentication;

using SerapisPatient.TabbedPages;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using SerapisPatient.Views.AppointmentFolder.Booking;
using SerapisPatient.Views.CustomViews;
using SerapisPatient.Views.MainViews;
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
        private SpecilizationModel _specilizationData;
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
                 MainPage = new NavigationPage(new LoginView());
                
            }
            else
            {
               
                //MainPage = new NavigationPage(new MasterDetailPage1());
                MainPage = new CustomNavigationView(new MasterView());
               // MainPage = new MasterView();
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
        //retreive yor gpslocation

            //base.OnResume();
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
