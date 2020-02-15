using SerapisPatient.Helpers;
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
            ButtonAppearanceLogic(Settings.UberRideRequestEnabled);
            ButtonCommand = new Command(UberRideRequest);
        }

   

        public Command ButtonCommand { get; set; }

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


        public string DistanceLabel
        {
            get
            {
                return Settings.MaximumDistance;
            }
            set
            {
                Settings.MaximumDistance = value;
                OnPropertyChanged("DistanceLabel");
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

        private void ButtonAppearanceLogic(string isSwitchedOn)
        {
            isSwitchedOn = Settings.UberRideRequestEnabled;

            if (isSwitchedOn != "Enabled")
            {
                DisableButtonProperties();
                Settings.UberRideRequestEnabled = "Enabled";
            }
            else
            {
                EnableButtonProperties();
                Settings.UberRideRequestEnabled = "Disabled";
            }
        }

        private void UberRideRequest()
        {
            ButtonAppearanceLogic(Settings.UberRideRequestEnabled);
            //Save in Settings
        }
    }
}
