using SerapisPatient.Models;
using SerapisPatient.ViewModels.AppointmentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.AppointmentFolder.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPracticeV2 : ContentPage
    {
        MedicalBuildingViewModel viewModel;
        public SelectPracticeV2(SpecilizationModel _specilizationData)
        {
            InitializeComponent();
            viewModel = new MedicalBuildingViewModel(_specilizationData);
            BindingContext = viewModel;
        }
    }
}