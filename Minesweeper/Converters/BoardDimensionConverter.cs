using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Minesweeper.Converters;

public class BoardDimensionConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int cellDimensionCount)
        {
            return cellDimensionCount * 26;
        }
        
        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}