using SerapisPatient.ViewModels.Base;

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
