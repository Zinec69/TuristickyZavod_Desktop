using Microsoft.UI.Xaml.Data;

namespace WinUI3.Helpers;

public class NullableIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var val = (int?)value;
        return val.HasValue ? val.Value.ToString() : "-";
    }

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
        => int.TryParse((string)value, out var val) ? (int?)val : null;
}
