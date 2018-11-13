using Rg.Plugins.Popup.Extensions;
using SerapisPatient.PopUpMessages;
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
	public partial class DummyPage : ContentPage
	{
		public DummyPage ()
		{
			InitializeComponent ();
		}
        private async void btnError_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AlertPopup("E", "Error!, Problem has been occurred while submitting your data."));
        }
        private async void btnWarn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AlertPopup("W", "Warning!, There was a problem with your Network Connection"));
        }
        private async void btnSucc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AlertPopup("S", "Success!, Your Message has been sent successfully."));
        }
        private async void btnNote_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushPopupAsync(new AlertPopup("N"));  
            await Navigation.PushPopupAsync(new AlertPopup("N", "Note!, Please read the comments carefully."));
        }

    }
}