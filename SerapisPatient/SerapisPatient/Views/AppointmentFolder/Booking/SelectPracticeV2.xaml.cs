using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Practices;
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

        private void practicedata_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            PracticeDto previousItem = e.PreviousItem as PracticeDto;
            PracticeDto currentItem = e.CurrentItem as PracticeDto;
            MessagingCenter.Send(this, "TEST2", currentItem);

        }
    }
}