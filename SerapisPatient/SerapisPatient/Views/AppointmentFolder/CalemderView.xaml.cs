using SerapisPatient.ViewModels.AppointmentViewModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SerapisPatient.PopUpMessages;

namespace SerapisPatient.Views.AppointmentFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalemderView : ContentPage
	{
        CalenderViewModel viewModel;
        public CalemderView ()
		{
			InitializeComponent ();
            viewModel = new CalenderViewModel();
            BindingContext = viewModel;
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync( new TimePickerPopUp());
        }
    }
}