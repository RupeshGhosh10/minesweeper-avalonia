using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Minesweeper.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    public GameViewModel()
    {
        RowCount = 16;
        ColumnCount = 16;
        _random = new Random();
        Cells = GenerateCells(RowCount, ColumnCount);
    }

    [ObservableProperty] 
    private ObservableCollection<CellViewModel> _cells;

    [ObservableProperty] 
    private int _rowCount;

    [ObservableProperty] 
    private int _columnCount;

    private static Random _random = null!;

    private static ObservableCollection<CellViewModel> GenerateCells(int row, int column)
    {
        var noOfMines = 40;
        var totalCells = row * column;
        var cells = new ObservableCollection<CellViewModel>();

        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < column; j++)
            {
                cells.Add(new CellViewModel(i + 1, j + 1, IsMine(ref noOfMines, ref totalCells)));
            }
        }

        return cells;
    }

    private static bool IsMine(ref int noOfMines, ref int totalCells)
    {
        var isMine = _random.Next(1, totalCells) <= noOfMines;
        if (isMine) noOfMines -= 1;
        totalCells -= 1;

        return isMine;
    }
}