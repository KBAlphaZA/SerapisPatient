using SerapisPatient.Services.DependencyServices;
using SerapisPatient.ViewModels.TabbedPageViewModel;
using SerapisPatient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppointmentPage : ContentPage
	{
        AppointmentViewModel viewModel;

        public AppointmentPage ()
		{
			InitializeComponent ();
            viewModel = new AppointmentViewModel();
            BindingContext = viewModel;
		}

       
    }
}