using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerapisPatient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmSerapisBooking : ContentPage
	{
        ConfirmationSerapisViewModel viewModel;

        public ConfirmSerapisBooking ()
		{
			InitializeComponent();
            viewModel = new ConfirmationSerapisViewModel();
            BindingContext = viewModel;
		}
	}
}