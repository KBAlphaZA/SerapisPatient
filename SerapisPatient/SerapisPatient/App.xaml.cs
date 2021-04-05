using MongoDB.Bson;
using Realms;
using SerapisPatient.Models;
using SerapisPatient.Models.Patient;
using SerapisPatient.Services;
using SerapisPatient.Services.Authentication;

using SerapisPatient.TabbedPages;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using SerapisPatient.Views.AppointmentFolder;
using SerapisPatient.Views.AppointmentFolder.Booking;
using SerapisPatient.Views.CustomViews;
using SerapisPatient.Views.MainViews;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SerapisPatient
{
	public partial class App : Application
	{

        public static bool CheckLogin { get; set; }
        public Realm _realm;
        public static string User = "Ceba";  //<-EXAMPLE
        #region Login services
        GoogleAuthentication googleToken = new GoogleAuthentication();
        FacebookAuthentication facebookToken = new FacebookAuthentication();
        MicrosoftAuthentication microsoftToken = new MicrosoftAuthentication();
        private SpecilizationModel _specilizationData;
        #endregion

        public App ()
		{
			InitializeComponent();
            _realm = Realm.GetInstance();
            //MainPage = new NavigationPage(new CheckIn());
            Init();

        }

        

        private void Init()
        {
            //check if the user still has a token for login

            CheckLogin = false;
            try
            {
                var dbuser = _realm.All<Patient>().FirstOrDefault();
                Debug.WriteLine("IS There a USER =>" + dbuser.ToJson());

                //if (!CheckLogin == true)
                if (dbuser == null)
                {
                        MainPage = new NavigationPage(new LoginView());

                }
                else
                {

                    MainPage = new NavigationPage(new MasterView());

                }
            }
            catch (Exception)
            {

                throw;
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
