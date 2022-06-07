using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TemplateViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultLoadingView : Popup
    {

        public DefaultLoadingView()
        {
            InitializeComponent();
        }

        public void DefaultLoadingView_Dismissed()
        {
            Dismiss(null);
        }
    }
}