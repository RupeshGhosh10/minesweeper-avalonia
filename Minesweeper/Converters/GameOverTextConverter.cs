using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Minesweeper.Enums;

namespace Minesweeper.Converters;

public class GameOverTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not GameStatus gameStatus)
            return "";

        return gameStatus switch
        {
            GameStatus.Lost => "Game Lost",
            GameStatus.Won => "Game Won",
            _ => ""
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}