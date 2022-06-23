using SerapisPatient.ViewModels.SymptomsCheckerViewModel;
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
    public partial class DevTestPage : ContentPage
    {

        private SymptomsCheckerViewModel viewModel;

        public DevTestPage()
        {
            InitializeComponent();
            viewModel = new SymptomsCheckerViewModel();
            BindingContext = viewModel;
        }
    }
}