
using SerapisPatient.Models;
using SerapisPatient.Views;
using SerapisPatient.Views.MainViews;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using SerapisPatient.TemplateViews;
using SerapisPatient.Models.Entities;
using SerapisPatient.Services.DB;
using Microsoft.AppCenter.Distribute;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SerapisPatient
{
	public partial class App : Application
	{

        public bool MockData = false;
        public static bool CheckLogin { get; set; }
        
        #region Login services
        
        public static SessionContext SessionCache = new SessionContext();
        public static List<string> SessionCache1= new List<string>();
        public static string User = "Unknown";  //<-EXAMPLE //Not to be used
        public RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
        public static string APIURL = "https://serapismedicalapi.azurewebsites.net/api"; //<- AZURE
        #endregion

        public App ()
        {
            SessionCache1 = new List<string>();
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
                    //Set Session user in case
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
            Microsoft.AppCenter.AppCenter.Start("android=d0703243-75a1-49fb-bd3e-3a9bf9fadd2f;" +
                            "uwp={Your UWP App secret here};" + 
                            "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
            Microsoft.AppCenter.AppCenter.Start("ios={Your Xamarin iOS App Secret};android=d0703243-75a1-49fb-bd3e-3a9bf9fadd2f", typeof(Distribute));

            base.OnResume();
        }

		protected override void OnSleep ()
		{
            // Handle when your app sleeps

        }

		protected override void OnResume ()
		{
            // Handle when your app resumes
            //TODO: Fix this
        }
	}
}
