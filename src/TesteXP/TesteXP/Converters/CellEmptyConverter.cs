using System;
using System.Globalization;
using Xamarin.Forms;

namespace TesteXP.Converters
{
    public class CellEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(value?.ToString())
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
