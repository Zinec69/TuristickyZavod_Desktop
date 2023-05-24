using Microsoft.UI.Xaml.Data;

namespace WinUI3.Helpers;

public class DateTimeDateTimeOffsetConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
        => new DateTimeOffset((DateTime)value);

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
        => ((DateTimeOffset)value).DateTime;
}
