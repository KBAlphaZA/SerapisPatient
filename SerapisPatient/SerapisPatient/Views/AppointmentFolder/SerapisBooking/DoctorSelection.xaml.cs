using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorSelection : ContentPage
	{
		public DoctorSelection ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Temp Navigation
            Navigation.PushModalAsync(new ConfirmSerapisBooking());
        }
    }
}