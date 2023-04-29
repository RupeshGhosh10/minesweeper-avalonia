using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Minesweeper.Models;

namespace Minesweeper.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    public GameViewModel()
    {
        Cells = GenerateCells(16, 16);
    }

    [ObservableProperty] 
    private ObservableCollection<Cell> _cells;
    
    private static ObservableCollection<Cell> GenerateCells(int row, int column)
    {
        var cells = new ObservableCollection<Cell>();
        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < column; j++)
            {
                cells.Add(new Cell { Row = i, Column = j });
            }
        }
        
        return cells;
    }
}