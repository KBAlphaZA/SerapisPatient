using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Services.Cloud;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{
    public class MedicalBuildingViewModel : BaseViewModel
    {
        public ObservableCollection<MedicalBuildingModel> Practices { get; set; }//MockData
        public ICommand NavigateToHomePageCommand => new Command(ConfirmBooking);

        public MedicalBuildingViewModel()
        {
            
            //GetMedicalBuildingsBySpecializationAsync();
            GenerateMedicalBuildingModel();
           
            
        }

        private void GenerateMedicalBuildingModel()
        {
            Practices = new ObservableCollection<MedicalBuildingModel>
            {
                new MedicalBuildingModel{Distance=7.8, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "Grey's Hospital", PatientsCurrentlyAtPractice=5},
                new MedicalBuildingModel{Distance=7.0, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "CromptomHospital", PatientsCurrentlyAtPractice=3},
                new MedicalBuildingModel{Distance=6.0, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "GrooteSchuurHospital",PatientsCurrentlyAtPractice=12},
                new MedicalBuildingModel{Distance=12.5,MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "PinetownClinic", PatientsCurrentlyAtPractice=20},
                new MedicalBuildingModel{Distance=8.0, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "WestvilleHospital", PatientsCurrentlyAtPractice=8},
                new MedicalBuildingModel{Distance=5.5, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "Medicross:Pinetown", PatientsCurrentlyAtPractice=11},
                new MedicalBuildingModel{Distance=2.5, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "Grey's Hospital", PatientsCurrentlyAtPractice=15},
            };


        }


        private  void ConfirmBooking()
        {
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully completed your booking"));
            // await Task.Delay(1500);
            //await App.Current.MainPage.Navigation.PushAsync(new SelectDoctor());
             App.Current.MainPage.Navigation.PushModalAsync(new SelectDoctor());
        }
        //public async Task<List<MedicalBuildingModel>> GetMedicalBuildingsBySpecializationAsync()
        //{
        //    //if (IsBusy)
        //     //   return;
        //    IsBusy = true;
        //    try
        //    {
        //        //var filter = Builders<MedicalBuildingModel>
        //         //.Filter
        //         //
        //         //.Eq(medicalbuilding, FieldsSpecilized);
        //        //adds filter to the query
        //        var result = await _mongodb.MedicalBuildingCollection
        //            .AsQueryable().Where(t => t.PracticeName.Equals("Grey's Hospital") )
        //            .ToListAsync();

        //        return result;
        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //    //filter function, this will filter by Medical building and specialization
        //    return null;
        //}

    }
}
