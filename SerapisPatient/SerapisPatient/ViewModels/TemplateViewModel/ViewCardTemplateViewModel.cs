using SerapisPatient.ViewModels.Base;

namespace SerapisPatient.ViewModels.TemplateViewModel
{
    public class ViewCardTemplateViewModel : BaseViewModel
    {
        public ViewCardTemplateViewModel()
        {

        }

        private string _icon;

        public string _Icon
        {
            get 
            { 
                return _icon; 
            }
            set 
            { 
                _icon = value;
                OnPropertyChanged("_Icon");
                _icon = value;
            }
        }

        private string _information;

        public string _Information
        {
            get 
            { 
                return _information; 
            }
            set 
            
            { 
                _information = value;
                OnPropertyChanged("_Information");
                _information = value;
            }
        }

    }
}
