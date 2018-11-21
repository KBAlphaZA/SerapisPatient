using SerapisPatient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class SpecilizationModel : BaseViewModel
    {
        private string title;
        private string icon;
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
    }
}
