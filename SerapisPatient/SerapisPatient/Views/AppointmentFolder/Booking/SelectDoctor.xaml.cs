using SerapisPatient.Models.Appointments;
using SerapisPatient.ViewModels.AppointmentViewModels.Booking;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.AppointmentFolder.Booking
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectDoctor : ContentPage
    {
        SelectDoctorViewModel viewModel;
		public SelectDoctor ( MedicalBuildingModel _MedicalBuildingData)
		{
			InitializeComponent ();

            BindingContext = viewModel = new SelectDoctorViewModel(_MedicalBuildingData);
		}

        
    }
}