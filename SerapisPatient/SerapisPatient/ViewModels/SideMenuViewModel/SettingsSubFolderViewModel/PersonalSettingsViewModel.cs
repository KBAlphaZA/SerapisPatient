using MongoDB.Bson;
using MongoDB.Driver;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.Helpers;
using SerapisPatient.Models.Entities;
using SerapisPatient.Models.Patient;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services.Data;
using SerapisPatient.Services.DB;
using SerapisPatient.TemplateViews;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.SideMenuPages.SettingsSubFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel
{
    public class PersonalSettingsViewModel : BaseViewModel
    {
        public ObservableCollection<object> NextOfKins { get; set; }
        public RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
        public PatientDao patient = new PatientDao();

        public PersonalSettingsViewModel()
        {
            Init();
            GenerateDummyList();

            //AddNextOfKin = new Command(AddToList);
            //SaveUserDetailsCommand
            SaveButton = new Command(
                execute: () =>
                {
                    SavePersonalSettings();
                },
                canExecute: () =>
                {
                    return true;
                });
            
        }

        #region Properties
        public Command SaveButton { get; set; }

        public Command AddNextOfKin{ get; set; }

        public string CellphoneNumberInput
        {
            get
            {
                return Settings.Cellphone;
            }
            set
            {
                Settings.Cellphone = value;
                OnPropertyChanged("CellphoneNumberInput");
            }
        }

        private string cellphonePlaceholder;
        public string CellphonePlaceholder
        {
            get
            {
                return cellphonePlaceholder;
            }
            set
            {
                cellphonePlaceholder = value;
                OnPropertyChanged("CellphonePlaceholder");
            }
        }

        public string AlternativeNumber
        {
            get
            {
                return Settings.AltPhoneNumber;
            }
            set
            {
                Settings.AltPhoneNumber = value;
                OnPropertyChanged("AlternativeNumber");
            }

            
        }

        private string alternativePlaceholder;
        public string AlternativePlaceholder
        {
            get
            {
                return alternativePlaceholder;
            }
            set
            {
                alternativePlaceholder = value;
                OnPropertyChanged("AlternativePlaceholder");
                SaveButtonVisability = true;
            }
        }

        private string emailPlaceholder;
        public string EmailPlaceholder
        {
            get
            {
                return emailPlaceholder;
            }
            set
            {
                emailPlaceholder = value;
                OnPropertyChanged("EmailPlaceholder");
            }
        }

        
        public string EmailText
        {
            get
            {
                return Settings.Email;
            }
            set
            {
                Settings.Email = value;
                OnPropertyChanged("EmailText");
            }
        }

        private bool saveButtonVisability;
        public bool SaveButtonVisability
        {

            get
            {
                return saveButtonVisability;
            }
            set
            {
              
                    value = saveButtonVisability;
                    OnPropertyChanged("SaveButtonVisability");
            }
        }

        public string FirstName
        {
            get
            {
                return Settings.FirstName;
            }
            set
            {
                Settings.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string Surname
        {
            get
            {
                return Settings.LastName;
            }
            set
            {
                Settings.LastName = value;
                OnPropertyChanged("Surname");
            }
        }

        private string genderPlaceholder;
        public string GenderPlaceholder
        {
            get { return genderPlaceholder; }
            set { genderPlaceholder = value; }
        }

        public string FullName 
        {
            get 
            {
                return FirstName+" "+Surname;
            }
            set
            {
                FullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string Birthdate
        {
            get
            {
                return Settings.DateOfBirth;
            }
            set
            {
                 MessagingCenter.Subscribe<PersonalSettings, string>(this, MessagingKeys.SaveSettings, (obj, sender)=> 
                {
                     value=sender;
                });

                 Settings.DateOfBirth = value;

                OnPropertyChanged("Birthdate");
            }
        }

        private double weight;
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (weight != 0)
                {
                    weight = value;
                    OnPropertyChanged("Weight");
                    SaveButtonVisability = true;
                }
            }
        }

        private bool bloodPressure;
        public bool BloodPressure
        {
            get
            {
                return bloodPressure;
            }
            set
            {
                    bloodPressure = value;
                    OnPropertyChanged("BloodPressure");
                    SaveButtonVisability = true;

            }
        }

        private bool smoker;
        public bool Smoker
        {
            get
            {
                return smoker;
            }
            set
            {
                smoker = value;
                OnPropertyChanged("Smoker");
                SaveButtonVisability = true;
            }
        }

        private string monthsSelectedIndex;
        public string MonthsSelectedIndex
        {
            get
            {
                return monthsSelectedIndex;
            }
            set
            {
                monthsSelectedIndex = value;
                RaisePropertyChanged(nameof(MonthsSelectedIndex));
            }
        }

        public Patient SessionUser { get; set; }
        #endregion

        #region Methods
        private async void Init()
        {
            //RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
            var dbuser = await userDb.RetrieveDocumentAsync();
            var sessionDataExist = App.SessionCache.CacheData.ContainsKey(CacheKeys.SessionUser.ToString());
            if (!sessionDataExist)
            {
                patient = await userDb.RetrieveDocumentAsync();
                var response = await CustomerAccountService.RetrieveUserInformationAsync(patient.id);
                Debug.WriteLine(response.data.ToJson());
                App.SessionCache.CacheData.Add(CacheKeys.SessionUser.ToString(), response.data);
                SessionUser = response.data;
                
            }
            SessionUser = (Patient) App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()];
            //FullName = dbuser.PatientFirstName;
            FirstName = dbuser.PatientFirstName;
            Surname = dbuser.PatientLastName;
            EmailPlaceholder = SessionUser.PatientContactDetails.Email;
            GenderPlaceholder = dbuser.Gender.ToString();
            CellphonePlaceholder = SessionUser.PatientContactDetails.CellphoneNumber;
            Birthdate = SessionUser.BirthDate.ToString();

        }
        private void GenerateDummyList()
        {
            //NextOfKins = new ObservableCollection<object>()
            //{
            //    new NextOfKin
            //    {
            //         ContactNumber="0787224416",
            //         FullName="Zothile Dlamini",
            //         RelationshipToPatient="Girlfriend"
            //    }
            //};
        }

        private void RemoveContact()
        {

        }

        private async void AddToList()
        {
            //generate the template

            //NextOfKins.Add(kinForm);

        }

        private async void SavePersonalSettings()
        {
            DefaultLoadingView popUp = new DefaultLoadingView();
            try
            {
                Debug.WriteLine(MonthsSelectedIndex);
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                {
                    popUp.IsLightDismissEnabled = false;
                }
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    App.Current.MainPage.Navigation.ShowPopup(popUp);

                SessionUser = (Patient) App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()];
                //Build new changes
                SessionUser.PatientFirstName = FirstName;
                SessionUser.PatientLastName = Surname;
                SessionUser.BirthDate = string.IsNullOrEmpty(Birthdate) ? SessionUser.BirthDate : DateTime.Parse(Birthdate);
                SessionUser.Gender = StringToGender(MonthsSelectedIndex);
                //CellPhone number should never change, User should request us to change it for them or create a new account
                SessionUser.PatientContactDetails.Email = EmailText;
                var response = await CustomerAccountService.UpdateUserInformation(SessionUser);
                if (!response.status)
                {
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Couldn't update details.. Please try again"));
                }
                Debug.WriteLine(response.message);
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "Your details have been updated."));
                patient.PatientFirstName = SessionUser.PatientFirstName;
                patient.PatientLastName = SessionUser.PatientLastName;
                patient.BirthDate = SessionUser.BirthDate;
                patient.Gender = SessionUser.Gender.ToString();
                var updatedDocument = await userDb.UpdateDocumentAsync(patient);
                Debug.WriteLine(updatedDocument);
                App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()] = SessionUser;


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    popUp.Dismiss(null);
            }
           

        }

        private void MaketheButtonVisable()
        {
            saveButtonVisability = true;
        }
        #endregion


        private Genders StringToGender(string gender)
        {
            switch(gender)
            {
                case "Male":
                    return Genders.male;
                case "Female":
                    return Genders.female;
                case "Non-Binary":
                    return Genders.other;
                default:
                    return Genders.other;
            }
        }
    }

    
}
