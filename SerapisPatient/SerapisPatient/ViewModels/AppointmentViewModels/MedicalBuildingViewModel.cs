
using MongoDB.Driver.Linq;
using SerapisPatient.behavious;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Services.Cloud;
using SerapisPatient.Utils;
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
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{
    public class MedicalBuildingViewModel : BaseViewModel
    {

        #region Properties
        
        public ObservableCollection<MedicalBuildingModel> Practices { get; set; }//MockData
        public MedicalBuildingModel _MedicalBuildingData;
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public Command NavigateToHomePageCommand { get; set; }
        public ICommand ItemSelected { get; set; }

        public MedicalBuildingModel SelectedItem
        {
            get { return GetValue<MedicalBuildingModel>(); }
            set { SetValue(value); }
        }

        private string title;
        public string Title 
        {
            get
            {
                return title;
            }
            set
            {
                title = value;

                RaisePropertyChanged(nameof(Title));
            }
        }

        private string icon;
        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;

                RaisePropertyChanged(nameof(Icon));
            }

        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;

                RaisePropertyChanged(nameof(Description));
            }

        }
        #endregion


        public MedicalBuildingViewModel(SpecilizationModel _specilizationData)
        {
            Title = _specilizationData.Title;
            Icon = _specilizationData.Icon;
            Description = _specilizationData.Description;


            GenerateMedicalBuildingModel();
            
            ItemSelected = new Command<MedicalBuildingModel>(args =>
            {
                _MedicalBuildingData = args;
                HandleNavigation(_MedicalBuildingData);
            });
        }

        public void HandleNavigation(MedicalBuildingModel _MedicalBuildingData)
        {
            App.Current.MainPage.Navigation.PushAsync(new SelectDoctor(_MedicalBuildingData), true);
        }
        private void GenerateMedicalBuildingModel()
        {
            Practices = new ObservableCollection<MedicalBuildingModel>
            {
                new MedicalBuildingModel{Distance=7.8, MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "Grey's Hospital", PatientsCurrentlyAtPractice=5},
                new MedicalBuildingModel{Distance=7.0, MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "CromptomHospital", PatientsCurrentlyAtPractice=3},
                new MedicalBuildingModel{Distance=6.0, MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "GrooteSchuurHospital",PatientsCurrentlyAtPractice=12},
                new MedicalBuildingModel{Distance=12.5,MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "PinetownClinic", PatientsCurrentlyAtPractice=20},
                new MedicalBuildingModel{Distance=8.0, MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "WestvilleHospital", PatientsCurrentlyAtPractice=8},
                new MedicalBuildingModel{Distance=5.5, MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "Medicross:Pinetown", PatientsCurrentlyAtPractice=11},
                new MedicalBuildingModel{Distance=2.5, MedicalBuildingImage ="MedicrossPinetown.jpg",PracticeName = "Grey's Hospital", PatientsCurrentlyAtPractice=15},
            };


        }

        public void ItemSelected_ExecuteCommand(object state)
        {
            SelectedItem = state as MedicalBuildingModel;
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
