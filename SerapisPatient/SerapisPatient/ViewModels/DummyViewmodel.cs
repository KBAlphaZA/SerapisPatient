using SerapisPatient.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.ViewModels
{
    public class DummyViewmodel
    {
        public ObservableCollection<MedicalBuildingModel> Practices { get; set; }//MockData
        public DummyViewmodel()
        {
            GenerateMedicalBuildingModel();
        }
        private void GenerateMedicalBuildingModel()
        {
            Practices = new ObservableCollection<MedicalBuildingModel>
            {
                new MedicalBuildingModel{Distance=7.8, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "Grey's Hospital", PatientsCurrentlyAtPractice=5},
                new MedicalBuildingModel{Distance=7.0, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "CromptomHospital", PatientsCurrentlyAtPractice=3},
                new MedicalBuildingModel{Distance=6.0, MedicalBuildingImage ="GrooteSchuurHospital.jpg",PracticeName = "GrooteSchuurHospital", PatientsCurrentlyAtPractice=12},
                new MedicalBuildingModel{Distance=12.5,MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "PinetownClinic", PatientsCurrentlyAtPractice=20},
                new MedicalBuildingModel{Distance=8.0, MedicalBuildingImage ="CromptonHospital.jpg",PracticeName = "WestvilleHospital", PatientsCurrentlyAtPractice=8},
                new MedicalBuildingModel{Distance=5.5, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "Medicross:Pinetown", PatientsCurrentlyAtPractice=11},
                new MedicalBuildingModel{Distance=2.5, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "Grey's Hospital", PatientsCurrentlyAtPractice=15},
            };

            
        }
    }
}
