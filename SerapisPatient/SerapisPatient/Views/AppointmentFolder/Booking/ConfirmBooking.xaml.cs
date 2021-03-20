using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.Practices;
using SerapisPatient.ViewModels;
using SerapisPatient.ViewModels.AppointmentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.AppointmentFolder.Booking
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmBooking : ContentPage
	{
        ConfirmBookingViewModel viewModel;

        public ConfirmBooking (Doctor enquiredDoctor, PracticeDto _medicalBuildingData, string FullDateAndMonth)
		{
			InitializeComponent ();
            viewModel = new ConfirmBookingViewModel(enquiredDoctor, _medicalBuildingData, FullDateAndMonth);
            BindingContext = viewModel;
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

			summaryCard.TranslationY = 2000;

			backgroundImage.Opacity = 0;

			summaryCard.TranslateTo(0, 0, 2000, Easing.SpringOut);

			backgroundImage.FadeTo(1, 1800, Easing.SinIn);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}
	}
}