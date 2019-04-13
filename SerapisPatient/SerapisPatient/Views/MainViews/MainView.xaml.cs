using SerapisPatient.PopUpMessages;
using SerapisPatient.ViewModels;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.MainViews
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
        //SelectedItem="{Binding SelectedCard}"
        const uint AnimationSpeed = 300;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //ConfirmBookingPopUp.OnExpandTapped += Expand
            
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
           
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var pageHeight = Height;
            //var section = ConfirmBookingPopUp.FirstSectionHeight;
            
        }
    }
}