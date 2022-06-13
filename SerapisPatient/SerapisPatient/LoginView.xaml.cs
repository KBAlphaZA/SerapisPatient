using SerapisPatient.ViewModels;
using Xamarin.Forms;

namespace SerapisPatient
{
	public partial class LoginView : ContentPage
	{
        LoginViewModel viewModel;

        public LoginView()
		{
			InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
			
		}
	}
}
