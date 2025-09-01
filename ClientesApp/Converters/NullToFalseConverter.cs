using System.Globalization;

namespace ClientesApp.Converters;

public class NullToFalseConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
      return string.IsNullOrWhiteSpace(value?.ToString()) ? false : true;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}