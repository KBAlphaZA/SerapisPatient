using System;
using System.Globalization;
using Xamarin.Forms;

namespace SerapisPatient.Helpers.ValueConvertors
{
    public class EnumToImageConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ImageSource)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Models.Doctor.TypeOfMedication)value ;
        }
    }
}
