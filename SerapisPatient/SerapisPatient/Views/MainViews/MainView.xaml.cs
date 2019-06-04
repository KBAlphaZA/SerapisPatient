using SerapisPatient.PopUpMessages;
using SerapisPatient.ViewModels;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.MainViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
        MainViewModel viewModel;
        public MainView ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new MainViewModel();
        }
        
        const uint AnimationSpeed = 300;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //CheckUp.OnExpandTapped += ExpandPopup;
        }

        private void ExpandPopup()
        {
            //var height = CheckUp.Height;

            //CheckUp.TranslateTo(0, this.Height - height, AnimationSpeed, Easing.SinInOut);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //CheckUp.OnExpandTapped -= ExpandPopup;
           
        }

        private void NotificationTapped(object sender, EventArgs e)
        {
            var pageHeight = Height;
            //var firstSection = CheckUp.FirstSectionHeight;
         
            PageFader.IsVisible = true;
            PageFader.FadeTo(1, AnimationSpeed, Easing.SinInOut);
            //CheckUp.TranslateTo(0, pageHeight - firstSection, AnimationSpeed, Easing.SinInOut);
        }

        private async void PageFader_Tapped(object sender, EventArgs e)
        {
            //CheckUp.TranslateTo(0, Height, AnimationSpeed, Easing.SinInOut);
            //You can repeat all the Translations here
            await PageFader.FadeTo(0, AnimationSpeed, Easing.SinInOut);
            PageFader.IsVisible = false;
           
        }
    }
}