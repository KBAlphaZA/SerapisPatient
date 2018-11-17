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
	public partial class MasterView : MasterDetailPage
    {
		public MasterView ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new MainTabPage());
        }
	}
}