using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using SerapisPatient.ViewModels.PopUpViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages
{
	
	public partial class DeliveryPopUp : PopupPage
    {
        DeliveryPopUpViewModel viewModel;

        public DeliveryPopUp ()
		{
			InitializeComponent ();
            viewModel = new DeliveryPopUpViewModel();
            BindingContext = viewModel;
		}

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

    }
}