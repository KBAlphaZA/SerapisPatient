using SerapisPatient.Models;
using SerapisPatient.Services.LocationServices;
using SerapisPatient.TabbedPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

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
       
    }
}
