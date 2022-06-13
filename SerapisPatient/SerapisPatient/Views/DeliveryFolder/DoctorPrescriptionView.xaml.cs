using SerapisPatient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorPrescriptionView : ContentPage
	{
        DoctorPrescriptionViewModel viewModel;

        public DoctorPrescriptionView ()
		{
			InitializeComponent ();
            viewModel = new DoctorPrescriptionViewModel();
            BindingContext = viewModel;
		}
	}
}