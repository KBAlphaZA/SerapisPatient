using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Practices;
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
        public SelectPractice(SpecilizationModel _specilizationData)
        {
            InitializeComponent();
            viewModel = new MedicalBuildingViewModel(_specilizationData);
            BindingContext = viewModel;
        }

        private void TLScrollView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            PracticeDto _medicalBuildingModelData = e.Item as PracticeDto;
            Navigation.PushAsync(new SelectBooking( _medicalBuildingModelData));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            practiceViewCard.TranslationX = -400;

            practiceViewCard.TranslateTo(0, 0, 1250, Easing.CubicInOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        //Come back to this, since this has to be moved to the viewmodel
        //private async Task TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new SelectDoctor(),true);
        //}





        //Below is the animation code(using Lottie)
        //transition between pages


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