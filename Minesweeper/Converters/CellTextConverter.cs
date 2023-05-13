using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Minesweeper.Model;

namespace Minesweeper.Converters;

public class CellTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Cell cell)
        {
            return cell.NearByMines > 0 ? cell.NearByMines.ToString() : "";
        }

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}