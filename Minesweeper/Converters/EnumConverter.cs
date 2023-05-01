using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Minesweeper.Converters;

public class EnumConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is null || value is null) return false;
        
        if (parameter is Enum expectedValue && value is Enum actualValue)
        {
            return Equals(actualValue, expectedValue);
        }

        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}