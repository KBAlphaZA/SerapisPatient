﻿using SerapisPatient.Models.Practices;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class PracticeSelectionViewModel:BaseViewModel
    {
        public ObservableCollection<PracticeInfo> PracticeList { get; set; }

        public ICommand GoToDocList => new Command(NavigateToDoctorsList);

        public PracticeSelectionViewModel()
        {
            GenerateDummyDataList();

        }



        private void NavigateToDoctorsList()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new SelectDoctor());
        }


        public void GenerateDummyDataList()
        {
            PracticeContact contact = new PracticeContact()
            {
                PracticeEmail = "Khanyisani.Buthelezi03@gmail.com",
                PracticeTelephoneNumber = "03170123423",
                TwitterHandle = "@Medicross"
            };

            PracticeLocation location = new PracticeLocation()
            {
                 Distance=10
            };

            PracticeLocation location2 = new PracticeLocation()
            {
                Distance = 12
            };

            PracticeList = new ObservableCollection<PracticeInfo>()
            {
                new PracticeInfo
                {
                    PracticeImage ="MedicrossPinetown.jpg",
                    NumOfPatientsInPractice =5,
                    OperatingTime ="8:00am-5:30pm",
                    PracticeName="MediCross: Pintown",
                    ContactP=contact,
                    Location=location
                }, 
                new PracticeInfo
                {
                    PracticeImage ="MedicrossPinetown.jpg",
                    NumOfPatientsInPractice =12,
                    OperatingTime ="7:00am-3:30pm",
                    PracticeName="Ja and Partners",
                    Location=location2
                }
            };


        }

        

    }
}
