using MongoDB.Bson;
using Realms;
using SerapisPatient.Enum;
using SerapisPatient.Models;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.Patient.Supabase;
using SerapisPatient.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TabbedViewModel
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ObservableCollection<ProfileModel> PatientCondtions { get; set; }
        public Command LoadMoreIcons { get; set; }
        public Realm _realm;

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private int myage;

        public int MyAge
        {
            get { return myage; }
            set { myage = value; }
        }

        public ProfilePageViewModel()
        {
            _realm = Realm.GetInstance();
            ProfilePageViewModelInit();

            LoadMoreIcons = new Command(LoadMore);
        }

        public void ProfilePageViewModelInit()
        {
            var dbuser = (Patient)App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()];
            Debug.WriteLine("DB USER =>" + dbuser.ToJson());
            FirstName = dbuser.PatientFirstName;
            MyAge = (dbuser.PatientAge);
            //MyAge = dbuser.PatientBloodType;
            GenerateList();
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
                Icon = "MyAllergies.png",
                Title = "Allergies"
            };
        }
    }
}