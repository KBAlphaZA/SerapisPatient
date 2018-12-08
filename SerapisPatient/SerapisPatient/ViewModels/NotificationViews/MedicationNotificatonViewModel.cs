using SerapisPatient.Models;
using SerapisPatient.ViewModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.ViewModels.NotificationViews
{
    public class MedicationNotificatonViewModel : BaseViewModel
    {
        public static IList<NotificationDetailModel> Delivery { get; private set; }

        private static DateTime TodayAt(int hour, int minute)
        {
            return new DateTime(DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                hour, minute, 0);
        }

        public MedicationNotificatonViewModel()
        {
            Delivery = new ObservableCollection<NotificationDetailModel>
            {
                new NotificationDetailModel
                {
                    Status = "Order Recieved",
                    DeliveryMode = "Drone Express",
                    Time = TodayAt(9,20),
                },
                 new NotificationDetailModel
                {
                    Status = "Medication Packed & Sealed",
                    DeliveryMode = "Drone Express",
                    Time = TodayAt(9,30),
                },
                 //new ExerciseClass
                //{
                //    ClassName = "Body Sculpt",
                //    Instructor = "Sadie Terry",
                //    ClassTime = DateTime.Now.AddHours(3),
                //},
                 new NotificationDetailModel
                {
                    Status = "In Transit",
                    DeliveryMode = "Drone Express",
                    Time = TodayAt(09,40),
                },
                 new NotificationDetailModel
                {
                    Status = "At Delivery Location",
                    DeliveryMode = "Drone Express",
                    Time = TodayAt(10,02),
                },
                 new NotificationDetailModel
                {
                    Status  = "Delivery Completed",
                    DeliveryMode= "Drone Express",
                    Time = TodayAt(10,05),
                    //IsLast = true
                },
            };
        }
    }
}
