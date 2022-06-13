using Rg.Plugins.Popup.Pages;
using SerapisPatient.ViewModels.AppointmentViewModels.Booking;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePickerPopUp : PopupPage
    {
        TimePickerPopUpVM viewModel;
		public TimePickerPopUp ()
		{
			InitializeComponent ();
            viewModel = new TimePickerPopUpVM();
            BindingContext = viewModel;
        }
	}
}