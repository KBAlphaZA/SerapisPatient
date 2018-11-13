using SerapisPatient.ViewModels;
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
	public partial class CameraPage : ContentPage
	{
        CameraViewModel viewModel;

        public CameraPage ()
		{
			InitializeComponent ();
            viewModel = new CameraViewModel();
            BindingContext = viewModel;
        }
	}
}