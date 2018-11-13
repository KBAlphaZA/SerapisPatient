using SerapisPatient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel
{
    public class AppointmentSettingsViewModel:BaseViewModel
    {

        public AppointmentSettingsViewModel()
        {
            
            ButtonCommand = new Command(UberRideRequest);
        }

   

        public Command ButtonCommand { get; set; }

        private bool saveButtonVisability;
        public bool SaveButtonVisability
        {
            get
            {
                return saveButtonVisability;
            }
            set
            {
                saveButtonVisability = value;
                OnPropertyChanged("SaveButtonVisability");
                ShowSaveButton();
            }
        }

        private string buttonText="Disable";
        public string ButtonText
        {
            get
            {
                return buttonText;
            }
            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }


        private string textColour="Black";
        public string TextColour
        {
            get
            {
                return textColour;
            }
            set
            {
                textColour = value;
                OnPropertyChanged("TextColour");
                textColour = value;
            }
        }


        private int distanceLabel=0;
        public int DistanceLabel
        {
            get
            {
                return distanceLabel;
            }
            set
            {
                distanceLabel = value;
                OnPropertyChanged("DistanceLabel");
                distanceLabel = value;
            }
        }


        private Color backgroundColour=Color.FromHex("#ffffff");
        public Color  BackgroundColour
        {
            get
            {
                return backgroundColour;
            }
            set
            {

                    backgroundColour = value;
                    OnPropertyChanged("BackgroundColour");
                    backgroundColour = value;
            }
        }


        private void EnableButtonProperties()
        {
            BackgroundColour = Color.FromHex("607d8b");
            ButtonText = "Enable";
            TextColour = "White";
        }

        private void DisableButtonProperties()
        {
            BackgroundColour = Color.White;
            ButtonText = "Disable";
            TextColour = "Black";
        }

        private void ButtonAppearanceLogic()
        {
            if (BackgroundColour.Equals(Color.FromHex("#607d8b")))
            {
                DisableButtonProperties();
            }
            else
            {
                EnableButtonProperties();
            }
        }

        private void ShowSaveButton()
        {
            
        }

        private void UberRideRequest()
        {
            ButtonAppearanceLogic();
            //Save in Settings
        }
    }
}
