using Microsoft.UI.Xaml.Data;

namespace WinUI3.Helpers;

public class DateTimeTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
        => (value as DateTime?)?.ToString("HH:mm:ss") ?? "-";

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
        => DateTime.TryParseExact(value as string, "HH:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out var res) ? res : null;
}
