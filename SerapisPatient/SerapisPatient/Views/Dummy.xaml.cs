using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.ViewModels.AppointmentViewModels;
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
	public partial class Dummy : ContentPage
	{
        MedicalBuildingViewModel viewModel; 
		public Dummy (SpecilizationModel _specilizationData)
		{
			InitializeComponent ();
            viewModel = new MedicalBuildingViewModel(_specilizationData);
            BindingContext = viewModel;
            
		}
	}
}