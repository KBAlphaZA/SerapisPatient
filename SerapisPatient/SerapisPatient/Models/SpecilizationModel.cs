using SerapisPatient.ViewModels.Base;

namespace SerapisPatient.Models
{
    public class SpecilizationModel : BaseViewModel
    {
        private string title;
        private string icon;
        private string description;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }
        public string Icon {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                RaisePropertyChanged("Icon");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }
    }
}
