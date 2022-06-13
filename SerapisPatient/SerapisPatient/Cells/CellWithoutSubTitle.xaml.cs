using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CellWithoutSubTitle : ViewCell
	{
		public CellWithoutSubTitle ()
		{
			InitializeComponent ();
		}
	}
}