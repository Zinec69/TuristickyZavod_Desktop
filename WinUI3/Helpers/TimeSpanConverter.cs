using Microsoft.UI.Xaml.Data;

namespace WinUI3.Helpers;

public class TimeSpanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
        => (value as TimeSpan?)?.ToString("hh\\:mm\\:ss") ?? "-";

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
        => TimeSpan.TryParseExact((string)value, "hh:mm:ss", null, System.Globalization.TimeSpanStyles.None, out var res) ? res : null;
}
