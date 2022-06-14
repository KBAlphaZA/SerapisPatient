using System.Collections.Generic;
using MvvmHelpers;
using SerapisPatient.Models;
using SerapisPatient.Utils;
using SerapisPatient.Views.SymptomsChecker;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class SymptomsActionPopUpViewModel : BaseViewModel
    {
        private List<PatientActions> _availableActions;
        public Command NavigateToNextPageCommand { get; }        
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
            NavigateToNextPageCommand = new Command(SaveSymptoms);
            AvailableActions = getPatientActions();
        }

        private List<PatientActions> getPatientActions() => OptionsLoader.GetPatientActions();

        private async void SaveSymptoms()
        {

            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}