using SerapisPatient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NetworkErrorPage : ContentPage
	{
        NetworkErrorPAgeViewModel viewModel;

        public NetworkErrorPage ()
		{
			InitializeComponent ();
            viewModel = new NetworkErrorPAgeViewModel();
            BindingContext = viewModel;
		}
	}
}