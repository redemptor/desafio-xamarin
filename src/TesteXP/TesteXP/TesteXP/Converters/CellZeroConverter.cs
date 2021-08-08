using System;
using System.Globalization;
using Xamarin.Forms;

namespace TesteXP.Converters
{
    public class CellZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is int valor && valor == 0)
                ? "-"
                : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "-"
                ? 0
                : value;
        }
    }
}
