using SerapisPatient.ViewModels;
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