using SerapisPatient.ViewModels;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
        MainViewModel viewModel;
        public MainView ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new MainViewModel();
        }
        private async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            //appointmentframe

            await appointmentframe.FadeTo(0.3, 500);
            await appointmentframe.FadeTo(1, 500);

            await Navigation.PushAsync(new SelectDoctor());

        }

        private async Task TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await appointmentframe1.FadeTo(0.3, 500);
            await appointmentframe1.FadeTo(1, 500);

            await Navigation.PushAsync(new SelectDoctor());
        }

        private async Task TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await appointmentframe2.FadeTo(0.3, 500);
            await appointmentframe2.FadeTo(1, 500);

            await Navigation.PushAsync(new SelectDoctor());
        }

        private async Task ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectDoctor());
        }
    }
}