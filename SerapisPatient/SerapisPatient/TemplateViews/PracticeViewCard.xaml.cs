using SerapisPatient.ViewModels.AppointmentViewModels;
using SerapisPatient.ViewModels.TemplateViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TemplateViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticeViewCard : ContentView
    {
        //TemplateViewModel viewModel;
        MedicalBuildingViewModel viewModel;
        public PracticeViewCard()
        {
            InitializeComponent();
            viewModel = new MedicalBuildingViewModel();
            BindingContext = viewModel;
        }
        
    }
}