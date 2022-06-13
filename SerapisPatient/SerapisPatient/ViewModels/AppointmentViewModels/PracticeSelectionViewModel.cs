using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Practices;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class PracticeSelectionViewModel:BaseViewModel
    {
        public ObservableCollection<PracticeInfo> PracticeList { get; set; }

        //The building info to pass on to the next page
        MedicalBuildingModel newBuilding = new MedicalBuildingModel()
        {
             
        };

        public Command GoToDocList => new Command(()=>NavigateToDoctorsList(newBuilding));

        public PracticeSelectionViewModel()
        {
          
           
        }



        private void NavigateToDoctorsList(MedicalBuildingModel _medicalBuildingModelData)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new SelectDoctor(_medicalBuildingModelData));
        }


        //public void GenerateDummyDataList()
        //{
        //    PracticeContact contact = new PracticeContact()
        //    {
        //        PracticeEmail = "Khanyisani.Buthelezi03@gmail.com",
        //        PracticeTelephoneNumber = "03170123423",
        //        TwitterHandle = "@Medicross"
        //    };

        //    PracticeLocation location = new PracticeLocation()
        //    {
        //         Distance=10
        //    };

        //    PracticeLocation location2 = new PracticeLocation()
        //    {
        //        Distance = 12
        //    };

        //    PracticeList = new ObservableCollection<PracticeInfo>()
        //    {
        //        new PracticeInfo
        //        {
        //            PracticeImage ="MedicrossPinetown.jpg",
        //            NumOfPatientsInPractice =5,
        //            OperatingTime ="8:00am-5:30pm",
        //            PracticeName="MediCross: Pintown",
        //            ContactP=contact,
        //            Location=location
        //        }, 
        //        new PracticeInfo
        //        {
        //            PracticeImage ="MedicrossPinetown.jpg",
        //            NumOfPatientsInPractice =12,
        //            OperatingTime ="7:00am-3:30pm",
        //            PracticeName="Ja and Partners",
        //            Location=location2
        //        }
        //    };


        //}

        public void ShowDetails()
        {
            MessagingCenter.Subscribe<SpecilizationViewModel,SpecilizationModel>(this, MessagingKeys.Specilization, (obj, arg) =>
             {
                 string icon = arg.Icon;
                 string Practicetitle = arg.Title;
             });
        }


    }
}
