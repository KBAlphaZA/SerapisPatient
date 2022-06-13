using SerapisPatient.Enum;
using SerapisPatient.Models;
using SerapisPatient.Models.Practices;
using SerapisPatient.ViewModels.AppointmentViewModels;
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
            App.SessionCache.CacheData.Remove(CacheKeys.SelectedPractice.ToString());
            App.SessionCache.CacheData.Add(CacheKeys.SelectedPractice.ToString(), currentItem);
            /*if (App.SessionCache.CacheData.ContainsKey("Practice"))
            {
                
                App.SessionCache.CacheData[CacheKeys.SelectedPractice.ToString()] = currentItem;
            }
            else
            {
                App.SessionCache.CacheData.Add(CacheKeys.SelectedPractice.ToString(), currentItem);
            }*/

            //App.SessionCache.CacheData.Add("","");
            //MessagingCenter.Send(this, "TEST2", currentItem);

        }
    }
}