using SerapisPatient.ViewModels;
using System;
using System.Diagnostics;
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

        const uint shorterAnimationDuration=1800;

        const uint longerAnimationDuration = 2000;

        protected override void OnAppearing()
        {
            
            //viewModel.OnAppearing(noticeBoardList,userName,message,noticeBoardLabel, appointmentButton,medicationButton, scanButton);
            //base.OnAppearing();
            //CheckUp.OnExpandTapped += ExpandPopup;

            //Origanal positions
            noticeBoardList.TranslationX = 2000;

            userName.Opacity = 0;

            message.Opacity = 0;

            noticeBoardLabel.Opacity = 0;

            appointmentButton.TranslationX = 2000;

            medicationButton.TranslationX = 2000;

            scanButton.TranslationX = 2000;

            userName.FadeTo(1, shorterAnimationDuration, Easing.Linear);
            
            message.FadeTo(1, longerAnimationDuration, Easing.Linear);
            
            noticeBoardLabel.FadeTo(1, shorterAnimationDuration, Easing.Linear);

            appointmentButton.TranslateTo(0, 0, 1000, Easing.SinInOut);

            medicationButton.TranslateTo(0, 0,1200, Easing.SinInOut);

            scanButton.TranslateTo(0, 0, 1400, Easing.SinInOut);

            noticeBoardList.TranslateTo(0, 0, (longerAnimationDuration+300), Easing.SpringOut);

        }

        //private void ExpandPopup()
        //{
        //    var height = CheckUp.Height;

        //    CheckUp.TranslateTo(0, this.Height - height, AnimationSpeed, Easing.SinInOut);
        //}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //CheckUp.OnExpandTapped -= ExpandPopup;
           
        }

        private void NotificationTapped(object sender, EventArgs e)
        {
            //var pageHeight = Height;
            //var firstSection = CheckUp.FirstSectionHeight;

            //PageFader.IsVisible = true;
            //PageFader.FadeTo(1, AnimationSpeed, Easing.SinInOut);
            //CheckUp.TranslateTo(0, pageHeight - firstSection, AnimationSpeed, Easing.SinInOut);
            DisplayAlert("Worked", "Finally", "Cancel");
        }

        private void PageFader_Tapped(object sender, EventArgs e)
        {
            //CheckUp.TranslateTo(0, Height, AnimationSpeed, Easing.SinInOut);
            ////You can repeat all the Translations here
            //await PageFader.FadeTo(0, AnimationSpeed, Easing.SinInOut);
            //PageFader.IsVisible = false;
           
        }
    }
}