using MongoDB.Driver;
using SerapisPatient.Helpers;
using SerapisPatient.Models.Patient;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.SideMenuPages.SettingsSubFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel
{
    public class PersonalSettingsViewModel:BaseViewModel
    {
        public ObservableCollection<NextOfKin> NextOfKins { get; set; }

        NextOfKin kinForm = new NextOfKin()
        {
             ContactNumber="",
             FullName="",
             RelationshipToPatient=""
        };

        public PersonalSettingsViewModel()
        {

            GenerateDummyList();

            AddNextOfKin = new Command(AddToList);

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

        #endregion

        #region Methods
   
        private void GenerateDummyList()
        {
            NextOfKins = new ObservableCollection<NextOfKin>()
            {
                new NextOfKin
                {
                     ContactNumber="0787224416",
                     FullName="Zothile Dlamini",
                     RelationshipToPatient="Girlfriend"
                }
            };
        }

        private void RemoveContact()
        {

        }

        private void AddToList()
        {
            //generate the template

            NextOfKins.Add(kinForm);
        }

        private void SavePersonalSettings()
        {
            //Stick a messaging center here to send all the properties.

        }

        private void MaketheButtonVisable()
        {
            saveButtonVisability = true;
        }
        #endregion
    }

    
}
