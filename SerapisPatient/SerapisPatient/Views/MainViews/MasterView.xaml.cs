using SerapisPatient.ViewModels;
using SerapisPatient.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.MainViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : MasterDetailPage
    {
		public MasterView ()
		{
			InitializeComponent ();
            //Detail = new CustomNavigationView(new MainView());
            

            Detail = new NavigationPage(new MainView());
            NavigationPage.SetHasNavigationBar(this, false);

        }

       
    }
}