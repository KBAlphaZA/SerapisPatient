using SerapisPatient.ViewModels.PopUpViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveryPopUp : PopupPage
    {
        DeliveryPopUpViewModel viewModel;

        public DeliveryPopUp()
        {
            InitializeComponent();
            viewModel = new DeliveryPopUpViewModel();
            BindingContext = viewModel;
        }
        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}