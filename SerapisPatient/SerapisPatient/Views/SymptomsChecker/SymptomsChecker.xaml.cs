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
    public partial class SymptomsChecker : ContentPage
    {
        SymptomsCheckerViewModel viewModel;
        public SymptomsChecker()
        {
            InitializeComponent();

            SymptomsCheckerViewModel viewModel;
            viewModel = new SymptomsCheckerViewModel();
            BindingContext = viewModel;
        }
    }
}