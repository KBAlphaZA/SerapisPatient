using SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages.SettingsSubFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalSettings : ContentPage
	{
        PersonalSettingsViewModel viewModel;

        public PersonalSettings ()
		{
			InitializeComponent ();
            viewModel = new PersonalSettingsViewModel();
            BindingContext = viewModel;
		}
	}
}