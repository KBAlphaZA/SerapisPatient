using MongoDB.Driver;
using SerapisPatient.Helpers;
using SerapisPatient.Services;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		protected override bool OnBackButtonPressed()
		{
			
			return base.OnBackButtonPressed();
		}

		private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
		{
			MessagingCenter.Send(this, MessagingKeys.SaveSettings, (sender.ToString()));
		}
	}
}