using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Minesweeper.ViewModels;

namespace Minesweeper.Converters;

public class CellTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is CellViewModel cellViewModel)
        {
            if (cellViewModel.IsFlag) return "F";
            if (cellViewModel.Cell.IsMine) return "B";
            return cellViewModel.Cell.NearByMines > 0 ? cellViewModel.Cell.NearByMines.ToString() : "";
        }
        
        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}