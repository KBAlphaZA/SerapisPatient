using SerapisPatient.ViewModels.SymptomsCheckerViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private SymptomsCheckerViewModel viewModel;
        public Page1()
        {
            InitializeComponent();

            viewModel = new SymptomsCheckerViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {

            OnLoad();
            //base.OnAppearing();
        }

        public async Task OnLoad()
        {
            await viewModel.OnAppearing();
        }
    }
}