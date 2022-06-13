using SerapisPatient.ViewModels.SideMenuViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        SettingsViewModel viewModel;

        public SettingsPage ()
		{
			InitializeComponent ();
            viewModel = new SettingsViewModel();
            BindingContext = viewModel;
		}
	}
}