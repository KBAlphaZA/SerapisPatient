using SerapisPatient.ViewModels.AppointmentViewModels;
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
    public partial class PracticeViewCard : ContentView
    {
        MedicalBuildingViewModel viewModel;

        public PracticeViewCard()
        {
            InitializeComponent();
            viewModel = new MedicalBuildingViewModel();
            BindingContext = viewModel;
        }
    }
}