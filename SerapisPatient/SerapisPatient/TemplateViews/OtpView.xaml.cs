using SerapisPatient.ViewModels.TemplateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.TemplateViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtpView : ContentPage
    {
        OTPViewModel viewModel;
        public OtpView()
        {
            InitializeComponent();

            viewModel = new OTPViewModel();
            BindingContext = viewModel;
        }
    }
}