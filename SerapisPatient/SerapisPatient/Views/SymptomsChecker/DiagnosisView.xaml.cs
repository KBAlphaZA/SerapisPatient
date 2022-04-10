using SerapisPatient.ViewModels.SymptomsCheckerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SymptomsChecker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiagnosisView : ContentPage
    {
        
        public DiagnosisView()
        {
            InitializeComponent();
            
            //TODO: Replace with ViewModel
            DiagnosisViewModel viewModel;
            
            viewModel = new DiagnosisViewModel();
            BindingContext = viewModel;
        }
    }
}