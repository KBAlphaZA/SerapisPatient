using SerapisPatient.ViewModels.SymptomsCheckerViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerapisPatient.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

            var viewModel = new SymptomsCheckerViewModel();
            BindingContext = viewModel;
        }
    }
}