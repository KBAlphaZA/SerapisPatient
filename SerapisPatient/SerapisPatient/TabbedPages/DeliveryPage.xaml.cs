using SerapisPatient.ViewModels.TabbedViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeliveryPage : ContentPage
	{
        DeliveryPageViewModel viewModel;

        public DeliveryPage ()
		{
			InitializeComponent ();
            viewModel = new DeliveryPageViewModel();
            BindingContext = viewModel;
        }
	}
}