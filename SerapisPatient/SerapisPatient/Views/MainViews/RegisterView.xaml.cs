using SerapisPatient.TemplateViews;
using SerapisPatient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.MainViews
{
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class RegisterView : ContentPage
	{
        RegisterViewModel viewModel;
        public RegisterView ()
		{
			InitializeComponent ();
            viewModel = new RegisterViewModel();
            BindingContext = viewModel;
        }
	}
}