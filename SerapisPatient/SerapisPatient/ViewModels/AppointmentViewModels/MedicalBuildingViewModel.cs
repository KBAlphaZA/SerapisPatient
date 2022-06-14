
using CarouselView.FormsPlugin.Abstractions;
using MongoDB.Bson;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Practices;
using SerapisPatient.Services;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{

    public class MedicalBuildingViewModel : BaseViewModel
    {

        #region Properties
        private readonly APIServices _apiServices = new APIServices();
        //MockData List

        public MedicalBuildingModel _MedicalBuildingData;
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public Command NavigateToHomePageCommand { get; set; }
        public ICommand ItemSelected { get; set; }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;

                RaisePropertyChanged(nameof(Title));
            }
        }
        private string practicename;
        public string PracticeName
        {
            get
            {
                return practicename;
            }
            set
            {
                practicename = value;
                RaisePropertyChanged(nameof(PracticeName));
            }
        }

        private string icon;
        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;

                RaisePropertyChanged(nameof(Icon));
            }

        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;

                RaisePropertyChanged(nameof(Description));
            }

        }

        #region Khanyisani carousel code
        public ICommand SelectedPractice { get; set; }
        public Command selectedItem { get; set; }
        object cache = null;
        private int myPostion;

        public int MyPostion
        {
            get
            {
                return myPostion;
            }
            set
            {
                myPostion = value;
                OnPropertyChanged("MyPostion");
                myPostion = value;
            }
        }

        private ObservableCollection<PracticeDto> practiceList;

        public ObservableCollection<PracticeDto> PracticesList
        {
            get
            {
                return practiceList;
            }
            set
            {
                practiceList = value;
                OnPropertyChanged();
            }
        }
        private void MedicalBuildingViewInit(SpecilizationModel _specilizationData)
        {
            //var myCarsoul = new CarouselViewControl();
            LoadRealData();
            Title = _specilizationData.Title;

            Icon = _specilizationData.Icon;

            Description = _specilizationData.Description;
            //myCarsoul.ItemsSource = PracticesList;
            //myCarsoul.Position = 0;

            //V2 COMMAND
            SelectedPractice = new Command(() => HandleNavigationv2());
        }

        #endregion

        #endregion

        public MedicalBuildingViewModel(SpecilizationModel _specilizationData)
        {
            MedicalBuildingViewInit(_specilizationData);
        }


        public MedicalBuildingViewModel()
        {

        }
        
        public void HandleNavigationv2()
        {

            MessagingCenter.Subscribe<SelectPracticeV2, PracticeDto>(this, "TEST2", (obj, arg) =>
            {

                cache = arg;
            });

            if(cache == null)
            {
                cache = (PracticeDto) PracticesList.GetItem(0);
            }

            Debug.WriteLine("CACHE => "+cache.ToJson());
            long totalMemory = GC.GetTotalMemory(false) / 1024;
            Debug.WriteLine("GC MEMORY => " + totalMemory);

            App.Current.MainPage.Navigation.PushAsync(new SelectBooking(cache as PracticeDto), true);

        }
        public void HandleNavigation(PracticeDto _MedicalBuildingData)
        {

            App.Current.MainPage.Navigation.PushAsync(new SelectBooking(_MedicalBuildingData), true);

        }

        public async void LoadRealData()
        {
            await GetAllPracticesAsync();
        }
        public async Task<ObservableCollection<PracticeDto>> GetAllPracticesAsync()
        {
            try
            {
                ShowUI = false;
                IsBusy = true;
                //PracticesList = new ObservableCollection<PracticeDto>();
    
                PracticesList = await _apiServices.GetAllMedicalBuildingsAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            IsBusy = false;
            ShowUI = true;
            return PracticesList;
        }

    }
}