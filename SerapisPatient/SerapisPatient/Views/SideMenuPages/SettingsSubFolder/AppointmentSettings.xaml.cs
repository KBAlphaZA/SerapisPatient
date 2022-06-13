using SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages.SettingsSubFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppointmentSettings : ContentPage
	{
        AppointmentSettingsViewModel viewModel;

        public AppointmentSettings ()
		{
			InitializeComponent ();
            viewModel = new AppointmentSettingsViewModel();
            BindingContext = viewModel;
		}


	}
}