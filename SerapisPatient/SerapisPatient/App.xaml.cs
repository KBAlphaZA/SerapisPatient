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
using SerapisPatient.Services.Data;
using System.Collections.Generic;
using SerapisPatient.TemplateViews;
using SerapisPatient.Models.Entities;
using SerapisPatient.Services.DB;
using SerapisPatient.Enum;
using Device = Xamarin.Forms.Device;
using Xamarin.CommunityToolkit.Extensions;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SerapisPatient
{
	public partial class App : Application
	{

        public bool MockData = false;
        public static bool CheckLogin { get; set; }
        public static string User = "Ceba";  //<-EXAMPLE
        #region Login services
        public static SessionContext SessionCache = new SessionContext();
        public static Patient CurrentUser = new Patient();
        public RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
        BaseResponse<Patient> response = new BaseResponse<Patient> ();
        #endregion

        public App ()
		{
            SessionCache.CacheData = new Dictionary<string, object>();
			InitializeComponent();
            Init();

        }

        

        private void Init()
        {
            try
            {
                DefaultLoadingView popUp = new DefaultLoadingView();
                
                var dbuser = userDb.RetrieveDocument();
                //Debug.WriteLine("Is there a user =>" + dbuser.ToJson());

                if (dbuser == null || !dbuser.IsAuthenticated)
                {
                        userDb.ClearDatabase();
                        MainPage = new NavigationPage(new LoginViewV2());
                }
                else
                {
                    //Set Session user incase
                    MainPage = new NavigationPage(new MasterView());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
                MainPage = new NavigationPage(new LoginViewV2());
            }
        }

       

		protected override async void OnStart ()
		{

            //TODO:  retreive yor gpslocation

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
            //TODO: Fix this
            RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
            try
            {
                // We probably wanna store some cache somewhere to indicate where was the last page user was on and any data that was pulled
                var dbuser = userDb.RetrieveDocument();
                if (!dbuser.IsAuthenticated)
                {
                    MainPage = new NavigationPage(new LoginViewV2());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
		}
	}
}
