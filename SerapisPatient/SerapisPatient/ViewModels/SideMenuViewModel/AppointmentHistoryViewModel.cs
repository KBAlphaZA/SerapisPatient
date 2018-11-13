using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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

        public ObservableCollection<Appointment> AppointmentHistoryList { get;private set; }

        void GenerateDummy()
        {
            AppointmentHistoryList = new ObservableCollection<Appointment>()
            {
                 new Appointment{ DateBooked=DateTime.Now.ToString(), DoctorBooked=doctorSeen, TimeBooked="13h00", Venue="Grays hospital, 6 Calsi gardens, 11 Sunnyside Lane, Pinetown, 3610"}
            };
        }
        

    }
}
