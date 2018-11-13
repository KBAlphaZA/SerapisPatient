using SerapisPatient.ViewModels.SideMenuViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppointmentHistoryPage : ContentPage
	{
        AppointmentHistoryViewModel viewModel;

        public AppointmentHistoryPage ()
		{
			InitializeComponent ();
            viewModel = new AppointmentHistoryViewModel();
            BindingContext = viewModel;
		}
	}
}