using System;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using System.Collections.ObjectModel;
using System.Linq;
using SerapisPatient.Models.Bookings;

namespace SerapisPatient.ViewModels.SideMenuViewModel
{
    public class AppointmentHistoryViewModel
    {
        Doctor doctorSeen = new Doctor
        {
             FirstName="Khanyisani",
             LastName="Buthelezi",
        };

        public AppointmentHistoryViewModel()
        {
            GenerateDummy();
        }

        public ObservableCollection<Booking> AppointmentHistoryList { get;private set; }

        void GenerateDummy()
        {
            AppointmentHistoryList = new ObservableCollection<Booking>()
            {
                 new Booking
                 {
                     AppointmentDateTime = DateTime.Now, 
                     //DoctorsId=ObjectId.Parse("5bc9baff1c9d4400001badec"),
                     HasSeenGP = false
                 }
            };

            var t = AppointmentHistoryList.FirstOrDefault().DoctorsId;
        }
        

    }
}
