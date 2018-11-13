using SerapisPatient.Services.DependencyServices;
using SerapisPatient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PracticeSelection : ContentPage
	{
        PracticeSelectionViewModel viewModel;

        public PracticeSelection ()
		{
			InitializeComponent ();
            viewModel = new PracticeSelectionViewModel();
            BindingContext = viewModel;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    Device.StartTimer(TimeSpan.FromSeconds(0), () =>
        //    {
        //        //DependencyService.Get<ILoadingPageService>().HideLoadingPage();

        //        return false;
        //    });


        //}
    }
}