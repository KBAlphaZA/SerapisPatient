using Rg.Plugins.Popup.Pages;
using SerapisPatient.ViewModels.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterSelectionPopUp : PopupPage
	{
        FilterPopUpViewModel viewModel;

        public FilterSelectionPopUp ()
		{
			InitializeComponent ();
            viewModel = new FilterPopUpViewModel();
            BindingContext = viewModel;
		}
	}
}