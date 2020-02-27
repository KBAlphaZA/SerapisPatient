using SerapisPatient.ViewModels.TabbedPageViewModel;
using System;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CustomButtonOne.TranslationX = -400;

            CustomButtonTwo.TranslationX = -400;

            CustomButtonOne.TranslateTo(0, 0, 600, Easing.CubicOut);

            CustomButtonTwo.TranslateTo(0, 0, 1000, Easing.CubicOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }

    }
}