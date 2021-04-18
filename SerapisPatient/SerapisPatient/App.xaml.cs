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
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

            try
            {
                //Checks if there is logged in user, if true then take them straight to the main page
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
            /*AppCenter.Start("android=b70fd8b0-fec0-484f-bc58-266a1f1bcc3a;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));  

            base.OnResume();*/
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
