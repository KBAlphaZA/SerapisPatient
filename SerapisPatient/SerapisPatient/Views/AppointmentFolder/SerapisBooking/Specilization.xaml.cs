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
	public partial class Specilization : ContentPage
	{
        SpecilizationViewModel viewModel;

        public Specilization ()
		{
			InitializeComponent ();
            viewModel = new SpecilizationViewModel();
            BindingContext = viewModel;
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
           // DependencyService.Get<ILoadingPageService>().ShowLoadingPage(); 
        }
    }
}