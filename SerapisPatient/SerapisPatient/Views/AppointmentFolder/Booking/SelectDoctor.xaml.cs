using SerapisPatient.Services.DependencyServices;
using SerapisPatient.ViewModels.AppointmentViewModels.Booking;
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
	public partial class SelectDoctor : ContentPage
    {
        SelectDoctorViewModel viewModel;
		public SelectDoctor ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new SelectDoctorViewModel();
		}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        //    {
        //        DependencyService.Get<ILoadingPageService>().HideLoadingPage();

        //        return false;
        //    });
        //}
    }
}