using SerapisPatient.ViewModels.TabbedViewModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        ProfilePageViewModel viewModel;

        public ProfilePage ()
		{
			InitializeComponent ();
            viewModel = new ProfilePageViewModel();
            BindingContext = viewModel;
		}

        protected override async void OnAppearing()
        {
            await OnLoad();
        }

        public async Task OnLoad()
        {
            await viewModel.OnAppearing();
        }
    }
}