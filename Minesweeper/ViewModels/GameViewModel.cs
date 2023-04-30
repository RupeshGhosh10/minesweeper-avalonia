using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Minesweeper.Helper;

namespace Minesweeper.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    public GameViewModel()
    {
        RowCount = 16;
        ColumnCount = 16;
        GenerateBoard();
        Cells = new ObservableCollection<CellViewModel>(Cells);
    }

    [ObservableProperty] private ObservableCollection<CellViewModel> _cells;

    [ObservableProperty] private int _rowCount;

    [ObservableProperty] private int _columnCount;

    [RelayCommand]
    private void ResetBoard() => GenerateBoard();

    private void GenerateBoard()
    {
        GenerateCells(RowCount, ColumnCount);
        PopulateMines();
        PopulateNearbyNumbers();
    }

    private void CellClick(CellViewModel cellViewModel)
    {
        if (cellViewModel.IsClicked) return;

        cellViewModel.IsClicked = true;

        if (cellViewModel.NearByMines == 0)
        {
            FloodFillCells(cellViewModel);
        }
    }

    private void FloodFillCells(CellViewModel cellViewModel)
    {
        var x = cellViewModel.Row;
        var y = cellViewModel.Column;

        for (var i = x - 1; i <= x + 1; i++)
        {
            for (var j = y - 1; j <= y + 1; j++)
            {
                var neighbourCell = SelectCell(i, j);
                if (neighbourCell is { IsMine: false, IsClicked: false })
                {
                    neighbourCell.ClickCommand.Execute(neighbourCell);
                }
            }
        }
    }

    private CellViewModel? SelectCell(int row, int column) =>
        Cells.SingleOrDefault(x => x.Row == row && x.Column == column);

    private void GenerateCells(int row, int column)
    {
        var cells = new ObservableCollection<CellViewModel>();

        for (var i = 1; i <= row; i++)
        {
            for (var j = 1; j <= column; j++)
            {
                cells.Add(new CellViewModel(i, j, new RelayCommand<CellViewModel>(CellClick!)));
            }
        }

        Cells = cells;
    }

    private void PopulateMines()
    {
        var noOfMines = 40;
        var totalCells = RowCount * ColumnCount;

        for (var i = 1; i <= RowCount; i++)
        {
            for (var j = 1; j <= ColumnCount; j++)
            {
                var cell = SelectCell(i, j)!;
                cell.IsMine = IsMine(ref noOfMines, ref totalCells);
            }
        }
    }

    private void PopulateNearbyNumbers()
    {
        for (var i = 1; i <= RowCount; i++)
        {
            for (var j = 1; j <= ColumnCount; j++)
            {
                var cell = SelectCell(i, j)!;
                cell.NearByMines = CalculateNearbyMines(i, j);
            }
        }
    }

    private int CalculateNearbyMines(int x, int y)
    {
        var count = 0;
        for (var i = x - 1; i <= x + 1; i++)
        {
            for (var j = y - 1; j <= y + 1; j++)
            {
                var cell = SelectCell(i, j);
                if (cell is not null && cell.IsMine) count += 1;
            }
        }

        return count;
    }

    private static bool IsMine(ref int noOfMines, ref int totalCells)
    {
        var isMine = RandomProvider.Random.Next(1, totalCells) <= noOfMines;
        if (isMine) noOfMines -= 1;
        totalCells -= 1;

        return isMine;
    }
}