using SerapisPatient.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SerapisPatient.Views.MainViews;
using Xamarin.Forms;

namespace SerapisPatient.Utils
{
    public static class OptionsLoader
    {
        public static ObservableCollection<NotificationModel> Notifications { get; private set; }

        public static void LoadOptions()
        {

            GenerateNotificationList();
        }
        private static void GenerateNotificationList()
        {
            Notifications = new ObservableCollection<NotificationModel>
                  {
                    new NotificationModel{ Title = "FOLLOW UP", Body ="You have a follow up with Dr. Duma ", Type="FollowUp" },
                     new NotificationModel{ Title = "MEDICATION DELIVERY", Body ="Your ordered medication should be with you in a few hours ", Type="Delivery" },
                      new NotificationModel{ Title = "DELVIERED", Body =" View your reciept below" }
                  };

            Debug.WriteLine("Notification list count "+ Notifications.Count);
        }

        public  static List<PatientActions> GetPatientActions()
        {
            //var x = db.LoadDBOptionsForVersion(version, connstring,
            //);
            // Need to implement Firebase Remote Config | A/B testing
            return new List<PatientActions>()
            {
                new PatientActions()
                {
                    ID = 1,
                    Icon = "timeline.png",
                    Title = "Save To Profile",
                    Description = "Save these symptoms to your Diagnosis timeline ",
                    NavigationDeepLink = Application.Current.MainPage.Navigation.PushAsync(new MainView()),
                    IsEnabled = true,
                    LowestVersionEnabled = "0.1"
                },
                new PatientActions()
                {
                    ID = 2,
                    Icon = "recomed.jpeg",
                    Title = "Book an appointment with RecoMed",
                    Description = "go visit the doctor once your booking is accepted",
                    NavigationDeepLink = Application.Current.MainPage.Navigation.PushAsync(new MainView()),
                    IsEnabled = true,
                    LowestVersionEnabled = "0.1"
                }
            };
        }
       
    }
}
