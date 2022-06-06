using SerapisPatient.TemplateViews;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class MasterViewModel
    {
        public MasterViewModel()
        {
            DefaultLoadingView popUp = new DefaultLoadingView();

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                popUp.IsLightDismissEnabled = false;
            }

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                App.Current.MainPage.Navigation.ShowPopup(popUp);
        }
    }
}
