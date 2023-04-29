using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Minesweeper.Models;

namespace Minesweeper.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    public GameViewModel()
    {
        RowCount = 16;
        ColumnCount = 16;
        Cells = GenerateCells(RowCount, ColumnCount);
    }

    [ObservableProperty] 
    private ObservableCollection<Cell> _cells;

    [ObservableProperty]
    private int _rowCount;
    
    [ObservableProperty]
    private int _columnCount;
    
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