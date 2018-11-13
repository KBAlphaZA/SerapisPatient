using SerapisPatient.Models.Patient;
using SerapisPatient.ViewModels.Base;
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

        private string cellphoneNumberInput;
        public string CellphoneNumberInput
        {
            get
            {
                return cellphoneNumberInput;
            }
            set
            {
                if (cellphoneNumberInput != value)
                {
                    cellphoneNumberInput = value;
                    OnPropertyChanged("CellphoneNumberInput");
                    SaveButtonVisability = true;
                }
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

        private string alternativeNumber;
        public string AlternativeNumber
        {
            get
            {
                return alternativeNumber;
            }
            set
            {
                if (alternativeNumber != null)
                {
                    alternativeNumber = value;
                    OnPropertyChanged("AlternativeNumber");
                    SaveButtonVisability = true;
                }
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

        private string emailText;
        public string EmailText
        {
            get
            {
                return emailText;
            }
            set
            {
                if (emailText != value)
                {
                    emailText = value;
                    OnPropertyChanged("EmailText");
                    SaveButtonVisability = true;
                }
            }
        }

        private string bloodTypePlaceholder;
        public string BloodTypePlaceholder
        {
            get
            {
                return bloodTypePlaceholder;
            }
            set
            {
                bloodTypePlaceholder = value;
                OnPropertyChanged("BloodTypePlaceholder");
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

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != null)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                    SaveButtonVisability = true;
                }
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname != null)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                    SaveButtonVisability = true;
                }
            }
        }

        private string birthday;
        public string Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                if (birthday != null)
                {
                    birthday = value;
                    OnPropertyChanged("Birthday");
                    SaveButtonVisability = true;
                }
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
