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
	public partial class SideMenuPage : ContentPage
	{
        MenuViewModel viewModel;

        public SideMenuPage ()
		{
			InitializeComponent ();
            viewModel = new MenuViewModel();
            BindingContext = viewModel;
        }
	}
}