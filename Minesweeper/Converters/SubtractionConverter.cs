using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Minesweeper.Converters;

public class SubtractionConverter : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is [int totalMines, int flags])
            return totalMines - flags;
        
        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }
}