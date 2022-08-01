using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FiscalDeviceStatusDecoder.Presentation.Converters;

public class BoolToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (System.Convert.ToBoolean(value))
        {
            return Brushes.Black;
        }

        return Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}