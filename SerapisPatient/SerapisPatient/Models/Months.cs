using System;

namespace SerapisPatient.Models
{
    public partial class SelectedMonths
    {
        public Int32 MonthValue { get; set; }
    }

    public partial class Month
    {
        public int key { get; set; }
        public string Value { get; set; }

    }
    public partial class Months
    {
        public const string January = "January";
        public const string February = "February";
        public const string March = "March";
        public const string April = "April";
        public const string May = "May";
        public const string June = "June";
        public const string July = "July";
        public const string August = "August";
        public const string September = "September";
        public const string October = "October";
        public const string November = "November";
        public const string December = "December";
         
    }
}
