using SerapisPatient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.MainViews
{
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class RegisterView : ContentPage
	{
        RegisterViewModel viewModel;
        public RegisterView ()
		{
			InitializeComponent ();
            viewModel = new RegisterViewModel();
            BindingContext = viewModel;
        }
	}
}