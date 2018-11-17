using SerapisPatient.Services.DependencyServices;
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
	public partial class SelectPractice : ContentPage
	{
        MedicalBuildingViewModel viewModel;
        public SelectPractice ()
		{
			InitializeComponent ();
            viewModel = new MedicalBuildingViewModel();
            BindingContext = viewModel;
        }

        private async Task TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new SelectDoctor(),true);
        }

      


        //Below is the animation code(using Lottie)


        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    Device.StartTimer(TimeSpan.FromSeconds(0), () =>
        //    {
        //       // DependencyService.Get<ILoadingPageService>().HideLoadingPage();

        //        return false;
        //    });
        //}


        /// <summary>

        // private async void Button_Clicked(object sender, EventArgs e)
        // {
        // show the loading page...
        //   DependencyService.Get<ILoadingPageService>().InitLoadingPage(new LoadingPage());
        // DependencyService.Get<ILoadingPageService>().ShowLoadingPage();

        // just to showcase a delay...
        // await Task.Delay(2000);

        // navigate to next page...
        //            await Navigation.PushAsync(new SelectDoctor());

        // close the loading page...
        //DependencyService.Get<ILodingPageService>().HideLoadingPage();
        //}


        /// </summary>
        /// 

    }
}