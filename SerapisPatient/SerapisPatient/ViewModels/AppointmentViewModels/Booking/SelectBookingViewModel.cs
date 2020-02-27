using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.behavious;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MedicalBuildingModel _medicalBuildingData;
        public List<Month> Months { get; set; }
        public Dictionary<int, string> Monthkeys = new Dictionary<int, string>();
        public Dictionary<string, int> NumofDays = new Dictionary<string, int>();
        private List<Doctor> _doctors;
        private List<Doctor> convert_doctors;

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
        public SelectBookingViewModel(MedicalBuildingModel _medicalBuildingData1)
        {
            _medicalBuildingData = _medicalBuildingData1;
            //GenerateDoctorList();
            
            IsBusy = false;
            //Animation
            ShowUI = true;
            Showlistview = false;
            //DateSelected = SelectedItem.MonthValue.ToString();
            Months = GetMonths();
            GenerateDaysOfTheMonth();
            

        }

        #region Lists
        //This list is for the picker
        public List<Month> GetMonths()
        {
            var months = new List<Month>
            {
                new Month(){key=1, Value = Models.Months.January },
                 new Month(){key=2, Value = Models.Months.February },
                  new Month(){key=3, Value = Models.Months.March},
                   new Month(){key=4, Value = Models.Months.April },
                    new Month(){key=5, Value = Models.Months.May },
                     new Month(){key=6, Value = Models.Months.June },
                      new Month(){key=7, Value = Models.Months.July },
                       new Month(){key=8, Value = Models.Months.August },
                        new Month(){key=9, Value = Models.Months.September },
                         new Month(){key=10, Value = Models.Months.October},
                          new Month(){key=11, Value = Models.Months.November },
                           new Month(){key=12, Value = Models.Months.December },
            };
            return months;

        }

        //mockdata for the number of days in the current month
        public void GenerateDaysOfTheMonth()
        {
            Days = new ObservableCollection<SelectedMonths>
            {
                new SelectedMonths{MonthValue=1},
                new SelectedMonths{MonthValue=2},
                new SelectedMonths{MonthValue=3},
                new SelectedMonths{MonthValue=4},
                new SelectedMonths{MonthValue=5},
                new SelectedMonths{MonthValue=6},
                new SelectedMonths{MonthValue=7},
                new SelectedMonths{MonthValue=8},
                new SelectedMonths{MonthValue=9},
                new SelectedMonths{MonthValue=10},
                new SelectedMonths{MonthValue=11},
                new SelectedMonths{MonthValue=12},
                new SelectedMonths{MonthValue=13},
                new SelectedMonths{MonthValue=14},
                new SelectedMonths{MonthValue=15},
                new SelectedMonths{MonthValue=16},
                new SelectedMonths{MonthValue=17},
                new SelectedMonths{MonthValue=18},
                new SelectedMonths{MonthValue=19},
                new SelectedMonths{MonthValue=20},
                new SelectedMonths{MonthValue=21},
                new SelectedMonths{MonthValue=22},
                new SelectedMonths{MonthValue=23},
                new SelectedMonths{MonthValue=24},
                new SelectedMonths{MonthValue=25},
                new SelectedMonths{MonthValue=26},
                new SelectedMonths{MonthValue=27},
                new SelectedMonths{MonthValue=28},
                new SelectedMonths{MonthValue=29},
                new SelectedMonths{MonthValue=30},


            };
        }

        //yhis is the same as having the list
        public void GetMonthDict()
        {
            Monthkeys.Add(1, Models.Months.January);
            Monthkeys.Add(2, Models.Months.February);
            Monthkeys.Add(3, Models.Months.March);
            Monthkeys.Add(4, Models.Months.April);
            Monthkeys.Add(5, Models.Months.May);
            Monthkeys.Add(6, Models.Months.January);
            Monthkeys.Add(7, Models.Months.January);
            Monthkeys.Add(8, Models.Months.January);
            Monthkeys.Add(9, Models.Months.January);
            Monthkeys.Add(10, Models.Months.January);
            Monthkeys.Add(11, Models.Months.January);
            Monthkeys.Add(12, Models.Months.January);

        }
        public void GetMonthNumbers()
        {

            //Dictionary<string, int> NumofDays
            NumofDays.Add(Models.Months.January, DateTime.DaysInMonth(DateTime.Now.Year, 1)); //grab key value 
            NumofDays.Add(Models.Months.February, DateTime.DaysInMonth(DateTime.Now.Year, 2));
            NumofDays.Add(Models.Months.March, DateTime.DaysInMonth(DateTime.Now.Year, 3));
            NumofDays.Add(Models.Months.April, DateTime.DaysInMonth(DateTime.Now.Year, 4));
            NumofDays.Add(Models.Months.May, DateTime.DaysInMonth(DateTime.Now.Year, 5));
            NumofDays.Add(Models.Months.June, DateTime.DaysInMonth(DateTime.Now.Year, 6));
            NumofDays.Add(Models.Months.July, DateTime.DaysInMonth(DateTime.Now.Year, 7));
            NumofDays.Add(Models.Months.August, DateTime.DaysInMonth(DateTime.Now.Year, 8));
            NumofDays.Add(Models.Months.September, DateTime.DaysInMonth(DateTime.Now.Year, 9));
            NumofDays.Add(Models.Months.October, DateTime.DaysInMonth(DateTime.Now.Year, 10));
            NumofDays.Add(Models.Months.November, DateTime.DaysInMonth(DateTime.Now.Year, 11));
            NumofDays.Add(Models.Months.December, DateTime.DaysInMonth(DateTime.Now.Year, 12));
        }

        //API Call for DoctorView
        public List<Doctor> GetDoctors()
        {
            //The follwing will be used in production code
            //DoctorAvaliable = await _apiServices.GetDoctorsAsync();


            //This is for testing purposes
            DoctorAvaliable = new List<Doctor>() 
            { 
                 new Doctor()
                 { 
                     FirstName="Khanyisani", 
                     Id="1234", 
                     LastName="Buthelezi", 
                     ProfileImageUrl="userprofilepicture.png",
                     University="University of KwaZulu-Natal",
                     practices=new List<object>()
                     {
                         "", 
                         "", 
                         ""
                     },
                     Qualifications=new List<Qualification>()
                     {
                          new Qualification()
                          {
                             Abbr="MBch",
                             Degree="Bachalors",
                             Graduated=2012,
                             Specilization="General practioner",
                             Specilizationabbr="GP",
                             University="University of Kwazulu-Natal"
                          }
                     },
                     Time="09h00",
                     YearsOfExp="7"
                 },
                 new Doctor(){ FirstName="Bonga", Id="1234", LastName="Ngcobo", ProfileImageUrl="userprofilepicture.png"},
                 new Doctor(){ FirstName="William", Id="1234", LastName="Carter", ProfileImageUrl="userprofilepicture.png" }
            };

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
                    //should add the month value also to one string
                    MonthText = MonthsSelectedIndex.Value.ToString();
                    FullDateAndMonth = DateSelected + "/" + MonthText + "/" + DateTime.Now.Year.ToString();

                    //force this task on the UI thread so changes can be made on the listview
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Dummy Data
                        //GenerateDoctorList();

                        GetDoctors();
                        //Task.WaitAll(GetDoctors());

                        //Task.Delay(200);
                    });

                }
                else
                {
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, We couldn't complete your booking. Please Try Again"));
                }

            }
            catch (Exception e)
            {

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
            // MessagingCenter.Send(this, MessagingKeys.Medicalbuilding, doctorname);

            //Temp code for demo purposes
            _medicalBuildingData = new MedicalBuildingModel() { PracticeName = "Grays hospital" };

            await GoToConfirmation(enquiredDoctor, _medicalBuildingData, FullDateAndMonth);
        });

        private ObservableCollection<Doctor> GenerateDoctorList()
        {
            Doctors = new ObservableCollection<Doctor>
                  {
                    new Doctor{ LastName = "Zulu ", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png", FirstName="Bonga", Id=" ", practices=new List<object>(){" ", " " }, Qualifications=new List<Qualification>(){ new Qualification { Abbr=" ", Degree=" ", Graduated=12, Specilization="Gp", Specilizationabbr="GP", University="UKZN"}},  Time="9:00", YearsOfExp="20"},
                    new Doctor{ LastName = "Duma ", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png", FirstName="Zama", Id="", practices=new List<object>(){ }, Qualifications=new List<Qualification>(){ new Qualification { } },  Time="9:00", YearsOfExp="20"},
                    new Doctor{ LastName = "Moody ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png", FirstName="John", Id="", practices=new List<object>(){ }, Qualifications=new List<Qualification>(){ new Qualification {} },  Time="9:00", YearsOfExp="30"},
                    new Doctor{ LastName = "McGhee ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png", FirstName="Andiswa", Id="", practices=new List<object>(){ }, Qualifications=new List<Qualification>(){ new Qualification { } },  Time="9:00", YearsOfExp="13"}
                    //new Doctor{ LastName = "Naidoo", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Ngwenya ", University="MBchB(UFS)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Miller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Ronaldo ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Buthelezi ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Moodley", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Matsoso ", University="MBchB(UP)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Ngcobo ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    //new Doctor{ LastName = "Muller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},

            };

            return Doctors;
        }
        //Navigation
        private async Task GoToConfirmation(Doctor enquiredDoctor, MedicalBuildingModel _medicalBuildingData, string FullDateAndMonth)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmBooking(enquiredDoctor, _medicalBuildingData, FullDateAndMonth), true);
        }


        #endregion
    }
}
