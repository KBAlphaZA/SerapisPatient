using Rg.Plugins.Popup.Services;
using SerapisPatient.Utils;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.PopUpViewModel
{
    public class FilterPopUpViewModel
    {

        private Filtration filterBy;

        public Command FilterByPrescribedMed { get; set; }

        public Command FilterByDateCommand { get; set; }

        public Command FilterBySelfPrecribedCommand { get; set; }

        public FilterPopUpViewModel()
        {
            FilterByDateCommand = new Command(BringUpDatePicker);
            FilterByPrescribedMed = new Command(PrescribedMedParameter);
            FilterBySelfPrecribedCommand = new Command(SelfPrescribed);
        }

        private void BringUpDatePicker()
        {
            
            DatePicker picker = new DatePicker();
        }

        private async void PrescribedMedParameter()
        {

            filterBy = Filtration.PrescribedMedication;

            //send the filter info the the medicationviewmodel class
            MessagingCenter.Send(this, MessagingKeys.Filter, filterBy);

            //wait for the view to be sort before pop async execution
            await Task.Delay(1000);

            await PopupNavigation.Instance.PopAsync(true);
        }

        private async void SelfPrescribed()
        {
            filterBy = Filtration.SelfPrescribed;

            //send the filter info the medicationviewmodel class
            MessagingCenter.Send(this, MessagingKeys.Filter, filterBy);

            //wait for the view to be sort before pop async execution
            await Task.Delay(1000);

            //go back to medication history page
            await PopupNavigation.Instance.PopAllAsync(true);
        }

    }
}
