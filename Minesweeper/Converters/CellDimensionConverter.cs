using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Minesweeper.Converters;

internal class CellDimensionConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int cellDimensionCount && parameter is double boardDimension)
        {
            return boardDimension / (cellDimensionCount - 0.75);
        }

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}