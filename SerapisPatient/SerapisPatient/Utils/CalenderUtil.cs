using SerapisPatient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.Utils
{
    public static class CalenderUtil
    {
        public static Dictionary<string,int> GetMonthNumbers()
        {

            Dictionary<string, int> NumofDays = new Dictionary<string, int>();
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

            return NumofDays;
        }

        public static ObservableCollection<SelectedMonths> GenerateDaysOfTheMonth()
        {
            ObservableCollection<SelectedMonths> Days = new ObservableCollection<SelectedMonths>();
            Days = new ObservableCollection<SelectedMonths>();
            int maxdays = 30;
            for (int day = (int)DateTime.Now.Day; day < maxdays; day++)
            {
                Days.Add(new SelectedMonths { MonthValue = day });
            }
            return Days;
        }

        public static List<Month> GetMonths()
        {
           
            int monthnumber = DateTime.Now.Month;
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

            //Lets cap the date when they can book to 3 months in advance
            var updatedlist = months.GetRange(monthnumber, 3);

            return updatedlist;

        }
    }
}

