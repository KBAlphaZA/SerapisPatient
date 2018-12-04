using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
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

        

        public ConfirmBooking (Doctor enquiredDoctor, MedicalBuildingModel _medicalBuildingData)
		{
			InitializeComponent ();
            viewModel = new ConfirmBookingViewModel(enquiredDoctor, _medicalBuildingData);
            BindingContext = viewModel;
        }
	}
}