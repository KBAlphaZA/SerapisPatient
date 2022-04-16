using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using SerapisPatient.Models;
using SerapisPatient.Utils;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class SymptomsActionPopUpViewModel : BaseViewModel
    {
        private List<PatientActions> _availableActions;
        public List<PatientActions> AvailableActions
        {
            get => _availableActions;
            set
            {
                _availableActions = value;
                OnPropertyChanged("AvailableActions");
            }
        }

        public SymptomsActionPopUpViewModel()
        {
            AvailableActions = getPatientActions();
        }

        private List<PatientActions> getPatientActions() => OptionsLoader.GetPatientActions();
    }
}