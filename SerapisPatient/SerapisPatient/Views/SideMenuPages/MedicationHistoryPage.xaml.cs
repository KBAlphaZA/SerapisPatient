using SerapisPatient.ViewModels.SideMenuViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MedicationHistoryPage : ContentPage
	{

        MedicationHistoryViewModel viewModel;

        public MedicationHistoryPage ()
		{
			InitializeComponent ();
            viewModel = new MedicationHistoryViewModel();
            BindingContext = viewModel;
		}
	}
}