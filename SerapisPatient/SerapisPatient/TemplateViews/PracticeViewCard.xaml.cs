using SerapisPatient.ViewModels.AppointmentViewModels;
using SerapisPatient.ViewModels.TemplateViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TemplateViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticeViewCard : ContentView
    {
        TemplateViewModel viewModel;

        public PracticeViewCard()
        {
            InitializeComponent();
            viewModel = new TemplateViewModel();
            BindingContext = viewModel;
        }
    }
}