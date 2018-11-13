using SerapisPatient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Lottie.Forms;

namespace SerapisPatient.ViewModels
{
    public class DeliveryMedicationPopUpVm:BaseViewModel
    {
        private bool failed;

        public DeliveryMedicationPopUpVm()
        {

        }

        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        private string buttonLabel;
        public string ButtonLabel
        {
            get
            {
                return buttonLabel;
            }
            set
            {
                buttonLabel = value;
                OnPropertyChanged("ButtonLabel");
            }
        }

        private string loadAnimation;
        public string LoadAnimation
        {
            get
            {
                return loadAnimation;
            }
            set
            {
                if (failed == true)
                {
                    loadAnimation = "ErrorAnimation.json";
                }
                else
                {
                    loadAnimation = "ScanComplete.json";
                }
                OnPropertyChanged("LoadAnimation");
            }
        }

    }
}
