using SerapisPatient.behavious;
using SerapisPatient.Models;
using SerapisPatient.Models.Doctor;
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
    public class SelectBookingViewModel :BaseViewModel 
    {
        #region Properties
        Doctor enquiredDoctor;
        public List<Month> Months { get; set; }
        public Dictionary<int, string> Monthkeys = new Dictionary<int, string>();
        public Dictionary<string, int> NumofDays = new Dictionary<string, int>();
        SelectedMonths selected;

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
        private SelectedMonths selectedItem;
        public SelectedMonths SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
               
                ItemSelected();
            }
        }

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
        private int monthsSelectedIndex;
        public int MonthsSelectedIndex
        {
            get
            {
                return monthsSelectedIndex;
            }
            set
            {
                monthsSelectedIndex = value;
                RaisePropertyChanged(nameof(MonthsSelectedIndex));
                
                //this method was meant to accept the selected value and allow the method to consume it straight away
                //then add fire the activityloader while the new UI loads up.
                //GenerateDaysOfTheMonth(MonthsSelectedIndex);
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
        public SelectBookingViewModel()
        {
            GenerateDoctorList();
            IsBusy = false;
            Showlistview = false;
            //DateSelected = SelectedItem.MonthValue.ToString();
            Months = GetMonths();
            GenerateDaysOfTheMonth();
            
        }

        #region ListViews
        //This list is for the picker
        public List<Month> GetMonths()
        {
             var months = new List<Month>
            {
                new Month(){key=1, value = Models.Months.January },
                 new Month(){key=2, value = Models.Months.February },
                  new Month(){key=3, value = Models.Months.March},
                   new Month(){key=4, value = Models.Months.April },
                    new Month(){key=5, value = Models.Months.May },
                     new Month(){key=6, value = Models.Months.June },
                      new Month(){key=7, value = Models.Months.July },
                       new Month(){key=8, value = Models.Months.August },
                        new Month(){key=9, value = Models.Months.September },
                         new Month(){key=10, value = Models.Months.October},
                          new Month(){key=11, value = Models.Months.November },
                           new Month(){key=12, value = Models.Months.December },
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


            //OLD CODE -->
            //
            // int x = 0;
           //while(x < DateTime.DaysInMonth(DateTime.Now.Year, monthvalue) ) //25
           //{
                //int value = x + 1;
                //selected.MonthValue = value;
               // Days.Add(selected);
                
                //this is the replacement code using no object but a string
                // int value = x + 1;
                //Days.Add(value);
                
               // x++;
           //}
             //return Days;
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

        //DoctorListview
        public void GenerateDoctorList()
        {
            Doctors = new ObservableCollection<Doctor>
                  {
                    new Doctor{ LastName = "Zulu ", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png" },
                    new Doctor{ LastName = "Duma ", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Moody ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "McGhee ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Naidoo", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ngwenya ", University="MBchB(UFS)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Miller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ronaldo ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Buthelezi ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Moodley", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Matsoso ", University="MBchB(UP)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ngcobo ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Muller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},

            };
        }
        #endregion

        #region Methods
        private async Task ItemSelected()
        {
            IsBusy = true;
            await Task.Delay(700);
            // MessagingCenter.Send(this, "ItemSelected", SelectedItem);
            DateSelected = SelectedItem.MonthValue.ToString();
            //force this task on the UI thread so changes can be made on the listview
            Device.BeginInvokeOnMainThread(() =>
            {
                Showlistview = true;
                GenerateDoctorList();
               
                
            });
            

            IsBusy = false;
        }
        public ICommand SelectedCommand => new Command<Doctor>(async selectDoctor =>
        {
            NavigateNextPageRequest.Raise(new SelectedItemEvent { SelectedDoctor = selectDoctor });
            enquiredDoctor = selectDoctor;
            // MessagingCenter.Send(this, MessagingKeys.Medicalbuilding, doctorname);

            await GoToConfirmation(enquiredDoctor);
        });
        private async Task GoToConfirmation(Doctor enquiredDoctor)
        {
            //This sends the message of itemSelected       
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmBooking(enquiredDoctor), true);
        }
        #endregion

        //Notes

        //Create an object with properties for the list and return it:

        //public class YourType
        //{
        //    public List<object> Prop1 { get; set; }
        //    public List<int> Prop2 { get; set; }
        //}

        //public static YourType Method2(int[] array, int number)
        //{
        //    return new YourType { Prop1 = list1, Prop2 = list2 };
        //}
    }
}
