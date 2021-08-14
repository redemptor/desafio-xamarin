using System;
using System.Globalization;
using Xamarin.Forms;

namespace TesteXP.Converters
{
    public class CellPercentualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double valor && valor > 0
                ? $"{Math.Round(valor * 100, 0)}%"
                : "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
