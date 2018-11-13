using SerapisPatient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisPatient
{
	public partial class MainPage : ContentPage
	{
        MainPageViewModel viewModel;

        public MainPage()
		{
			InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
		}
	}
}
