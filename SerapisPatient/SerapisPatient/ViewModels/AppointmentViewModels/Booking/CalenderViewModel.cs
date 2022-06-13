using SerapisPatient.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.AppointmentViewModels.Booking
{
    public class CalenderViewModel : BaseViewModel
    {
        ObservableCollection<DateTime> dates;
        DateTime from;
        DateTime until;
        bool isNextEnabled;

        public ObservableCollection<DateTime> Dates
        {
            get => dates;
            //set => SetProperty(ref dates, value);
        }
        public DateTime OnDay
        {
            get => from;
           // set => SetProperty(ref from, value);
        }

        public CalenderViewModel()
        {
            var today = DateTime.Today;

            dates = new ObservableCollection<DateTime>
            {
                today
            };
        }

        public ICommand SelectedDateCommand => new Command((d) => SelectedDate(d));
        void SelectedDate(object date)
        {
            //if (date == null)
            //    return;

            //if (Dates.Any())
            //{
            //    OnDay = Dates.OrderBy(d => d.Day).FirstOrDefault();
                
            //}
        }
    }
}
