using SerapisPatient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginViewV2 : ContentPage
    {
        LoginViewModel viewModel;
        public LoginViewV2()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
        }
    }
}