using SerapisPatient.ViewModels.SideMenuViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppointmentHistoryPage : ContentPage
	{
        AppointmentHistoryViewModel viewModel;

        public AppointmentHistoryPage ()
		{
			InitializeComponent ();
            viewModel = new AppointmentHistoryViewModel();
            BindingContext = viewModel;
		}
	}
}