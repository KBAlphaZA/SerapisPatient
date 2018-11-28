using Rg.Plugins.Popup.Pages;
using SerapisPatient.ViewModels.AppointmentViewModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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