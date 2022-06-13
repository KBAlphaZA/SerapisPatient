using SerapisPatient.ViewModels.DeliveryViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.DeliveryFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MedicationCart : ContentPage
	{
		public MedicationCart ()
		{
			InitializeComponent ();
            this.BindingContext = new MedicationCartViewModel();
        }
	}
}