using Rg.Plugins.Popup.Pages;
using SerapisPatient.ViewModels.PopUpViewModel;
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