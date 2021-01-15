using SerapisPatient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisPatient
{
	public partial class LoginView : ContentPage
	{
        LoginViewModel viewModel;

        public LoginView()
		{
			InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
			
		}
	}
}
