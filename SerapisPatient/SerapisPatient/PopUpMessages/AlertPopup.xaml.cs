using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlertPopup : PopupPage 
	{
		public AlertPopup ()
		{
			InitializeComponent ();
		}

        public AlertPopup(string mtitle, string msg)
        {
            InitializeComponent();
            ChangecolorMsg(mtitle, msg);
        }
        private async void ChangecolorMsg(string mtitle, string msg)
        {
            if (mtitle == "W")
            {
                imgAlert.Source = "warning";
                Mainstk.BackgroundColor = Color.FromHex("#FCF8E3");
            }
            else if (mtitle == "S")
            {
                imgAlert.Source = "success";
                Mainstk.BackgroundColor = Color.FromHex("#43A047");
            }
            else if (mtitle == "E")
            {
                imgAlert.Source = "error";
                Mainstk.BackgroundColor = Color.FromHex("#F2DEDE");
            }
            else
            {
                imgAlert.Source = "note";
                Mainstk.BackgroundColor = Color.FromHex("#D9EDF7");
            }
            LblMsg.Text = msg;
            await Task.Delay(500);
            await Task.WhenAll(imgAlert.ScaleTo(1.3, 400), LblMsg.ScaleTo(1.1, 500), imgAlert.RotateTo(360, 600));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            HidePopup();
        }
        private async void HidePopup()
        {
            await Task.Delay(4000);
            await PopupNavigation.RemovePageAsync(this);
        }
    }
}