using SerapisPatient.ViewModels;
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