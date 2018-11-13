using Rg.Plugins.Popup.Pages;
using SerapisPatient.ViewModels;

namespace SerapisPatient.Views
{

	public partial class DeliveryMedicationPopUp : PopupPage
	{
        DeliveryMedicationPopUpVm viewModel;

        public DeliveryMedicationPopUp ()
		{
			InitializeComponent ();
            viewModel = new DeliveryMedicationPopUpVm();
            BindingContext = viewModel;
		}

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
	}
}