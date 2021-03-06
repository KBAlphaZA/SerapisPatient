using MongoDB.Bson;
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
            //AppointmentHistoryList = new ObservableCollection<Models.Appointments.Appointment>()
            //{
            //     new Models.Appointments.Appointment
            //     { 
            //         DateBooked=DateTime.Now, 
            //         DoctorsId=ObjectId.Parse("5bc9baff1c9d4400001badec"), 
            //         TimeBooked=DateTime.Now, 
            //         Venue=new Models.Address
            //         { 
            //            AddressLineOne="6 Calsi gardens",
            //            AddressLineTwo="11 Sunnyside Lane",
            //            CityTown="Pinetown",
            //            PostalCode="3610"
            //         }
            //     }
            //};
        }
        

    }
}
