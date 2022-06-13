using SerapisPatient.ViewModels.TemplateViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TemplateViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtpView : ContentPage
    {
        OTPViewModel viewModel;
        public OtpView()
        {
            InitializeComponent();

            viewModel = new OTPViewModel();
            BindingContext = viewModel;
        }
    }
}