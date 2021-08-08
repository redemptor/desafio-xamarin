using System;
using System.Globalization;
using TesteXP.Enums;
using Xamarin.Forms;

namespace TesteXP.Converters
{
    public class CellTipoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is EnumTipo valor
                ? valor.ToString().Substring(0, 1).ToUpper()
                : "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
