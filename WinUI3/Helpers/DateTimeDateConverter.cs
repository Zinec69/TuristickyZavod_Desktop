using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace WinUI3.Helpers;

public class DateTimeDateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
        => (value as DateTime?)?.ToString("dd.MM.yyyy") ?? "-";

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
        => DateTime.TryParseExact(value as string, "dd.MM.yyyy", null, DateTimeStyles.AssumeLocal, out var res) ? res : null;
}
