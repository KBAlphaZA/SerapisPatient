using Xamarin.CommunityToolkit.UI.Views;
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