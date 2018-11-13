using SerapisPatient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TabbedViewModel
{
    public class ProfilePageViewModel
    {
        public ObservableCollection<ProfileModel> PatientCondtions{ get; set; }
        public Command LoadMoreIcons { get; set; } 
        public ProfilePageViewModel()
        {
            GenerateList();
            LoadMoreIcons = new Command(LoadMore);
        }

        private void GenerateList()
        {
            PatientCondtions = new ObservableCollection<ProfileModel>()
            {
                new ProfileModel{Icon="MyAge.png", SubTitle="Age", Title="22" },
                new ProfileModel{Icon="MyMedicalAid.png", SubTitle="Medical Aid", Title="Bonits" },
                new ProfileModel{Icon="MyGender.png", SubTitle="Gender", Title="Male" },
                new ProfileModel{Icon="MyBloodType.png", SubTitle="Blood type", Title="A+" }
            };
        }

        private void LoadMore()
        {
            ProfileModel allergies = new ProfileModel()
            {
                Icon="MyAllergies.png", Title="Allergies"
            };

        }

    }
}
