using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.behavious;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Models.Practices;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels.Booking
{
    public class SelectBookingViewModel : BaseViewModel 
    {
        #region Properties
        private readonly APIServices _apiServices = new APIServices();
        public Doctor enquiredDoctor;
        public string FullDateAndMonth = " ";

        public PracticeDto _medicalBuildingData = new PracticeDto() {};
        public List<Month> Months { get; set; }
        public Dictionary<int, string> Monthkeys = new Dictionary<int, string>();
        public Dictionary<string, int> NumofDays = new Dictionary<string, int>();
        private List<Doctor> _doctors;

        public List<Doctor> DoctorAvaliable
        {
            get { return _doctors; }
            set
            {
                _doctors = value;
                OnPropertyChanged();
            }
            
        }

        public ObservableCollection<Doctor> Doctors { get; set; }

        public ICommand NavigateToConfrimation { get; set; }

        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();

        private ObservableCollection<SelectedMonths> days;
        public ObservableCollection<SelectedMonths> Days
        {
            get => days;
            set => SetProperty(ref days, value);
        }

        //this selected_item command is for the horizontallistview
        private SelectedMonths selectedDay;
        public SelectedMonths SelectedDay
        {
            get => selectedDay;
            set
            {
                SetProperty(ref selectedDay, value);

                //Method requests and loads up data(Avaliable doctors)
                ItemSelected();
            }
        }

        //value is being converted to a string
        private string dateSelected;
        public string DateSelected
        {
            get => dateSelected;
            set
            {
                dateSelected = value;
                RaisePropertyChanged(nameof(DateSelected));
            }
        }

        private Month monthsSelectedIndex;
        public Month MonthsSelectedIndex
        {
            get
            {
                return monthsSelectedIndex;
            }
            set
            {
                monthsSelectedIndex = value;
                RaisePropertyChanged(nameof(MonthsSelectedIndex));

                ShowUI = true;
                //this method was meant to accept the selected value and allow the method to consume it straight away
                //then add fire the activityloader while the new UI loads up.
                //GenerateDaysOfTheMonth(MonthsSelectedIndex);
            }
        }
        private string monthText;
        public string MonthText
        {
            get
            {
                return monthText;
            }
            set
            {
                SetProperty(ref monthText, value);
            }
        }

        private bool showlistview;
        public bool Showlistview
        {
            get
            {
                return showlistview;
            }
            set
            {
                showlistview = value;
                OnPropertyChanged("Showlistview");
            }
        }


        #endregion
        public SelectBookingViewModel(PracticeDto _medicalBuildingData1)
        {
            _medicalBuildingData = _medicalBuildingData1;
            
            IsBusy = false;
            //Animation
            ShowUI = true;
            Showlistview = false;
            NumofDays = CalenderUtil.GetMonthNumbers();

            Months = CalenderUtil.GetMonths();

            Days = CalenderUtil.GenerateDaysOfTheMonth();

        }

        #region Lists

        //API Call for DoctorView
        public async Task<List<Doctor>> GetDoctors()
        {
           
            DoctorAvaliable = await _apiServices.GetDoctorsAsync();

            return DoctorAvaliable;

        }

        #endregion


        #region Methods
        private async Task ItemSelected()
        {
            try
            {
                IsBusy = true;
                await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("W", "We Are loading Avaliable Doctors "));
                //2await Task.Delay(1500);
                if (CrossConnectivity.Current.IsConnected)
                {
                    //Date Value eg.7th
                    //should add the month value also to one string
                    
                    DateSelected = SelectedDay.MonthValue.ToString();

                    DateSelected = StringUtil.DeterimineCorrectSuffixForDate(DateSelected);

                    if(MonthsSelectedIndex == null)
                    {
                        //THROW A POP ERRO AND INFORM USER TO SELECT A MONTH FIRST
                        await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, We couldn't complete your booking. Please Try Again"));
                    }
                    MonthText = MonthsSelectedIndex?.Value.ToString();
                    FullDateAndMonth = DateSelected + "/" + MonthText + "/" + DateTime.Now.Year.ToString();


                    //force this task on the UI thread so changes can be made on the listview
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await GetDoctors();
                    });
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, We couldn't complete your booking. Please Try Again"));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error ", e);
            }
            finally
            {
                IsBusy = false;
                ShowUI = false;
                Showlistview = true;
            }

        }
        public ICommand SelectedCommand => new Command<Doctor>(async selectDoctor =>
        {
            NavigateNextPageRequest.Raise(new SelectedItemEvent { SelectedDoctor = selectDoctor });
            enquiredDoctor = selectDoctor;
            

            await GoToConfirmation(enquiredDoctor, _medicalBuildingData, FullDateAndMonth);
        });

       
        //Navigation
        private async Task GoToConfirmation(Doctor enquiredDoctor, PracticeDto _medicalBuildingData, string FullDateAndMonth)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmBooking(enquiredDoctor, _medicalBuildingData, FullDateAndMonth), true);
        }


        #endregion
    }
}
