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
        public delegate void DismissPopUpDelegate();
        public DismissPopUpDelegate OnDismissPopup { get; set; }
        public DefaultLoadingView()
        {
            InitializeComponent();
            //Dismissed += DefaultLoadingView_Dismissed;  
        }

        public void DefaultLoadingView_Dismissed()
        {
            Dismiss(null);
        }
    }
}