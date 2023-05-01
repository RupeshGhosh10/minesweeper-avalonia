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
        CellViewModels = new ObservableCollection<CellViewModel>(CellViewModels);
    }

    [ObservableProperty] private ObservableCollection<CellViewModel> _cellViewModels;

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

    private void CellLeftClick(CellViewModel? cellViewModel)
    {
        if (cellViewModel is null || cellViewModel.IsRevealed || cellViewModel.IsFlag)
            return;

        cellViewModel.IsRevealed = true;

        if (cellViewModel.Cell.NearByMines == 0)
        {
            FloodFillCells(cellViewModel);
        }
    }

    private void CellRightClick(CellViewModel? cellViewModel)
    {
        if (cellViewModel is null || cellViewModel.IsRevealed)
            return;

        cellViewModel.IsFlag = !cellViewModel.IsFlag;
    }

    private void FloodFillCells(CellViewModel cellViewModel)
    {
        var x = cellViewModel.Cell.Row;
        var y = cellViewModel.Cell.Column;

        for (var i = x - 1; i <= x + 1; i++)
        {
            for (var j = y - 1; j <= y + 1; j++)
            {
                var neighbourCellViewModel = SelectCell(i, j);
                if (neighbourCellViewModel is { Cell.IsMine: false, IsRevealed: false })
                {
                    neighbourCellViewModel.LeftClickCommand.Execute(neighbourCellViewModel);
                }
            }
        }
    }

    private CellViewModel? SelectCell(int row, int column) =>
        CellViewModels.SingleOrDefault(x => x.Cell.Row == row && x.Cell.Column == column);

    private void GenerateCells(int row, int column)
    {
        var cells = new ObservableCollection<CellViewModel>();

        for (var i = 1; i <= row; i++)
        {
            for (var j = 1; j <= column; j++)
            {
                var leftClickCommand = new RelayCommand<CellViewModel>(CellLeftClick);
                var rightClickCommand = new RelayCommand<CellViewModel>(CellRightClick);
                cells.Add(new CellViewModel(i, j, leftClickCommand, rightClickCommand));
            }
        }

        CellViewModels = cells;
    }

    private void PopulateMines()
    {
        var noOfMines = 40;
        var totalCells = RowCount * ColumnCount;

        for (var i = 1; i <= RowCount; i++)
        {
            for (var j = 1; j <= ColumnCount; j++)
            {
                var cellViewModel = SelectCell(i, j)!;
                cellViewModel.Cell.IsMine = IsMine(ref noOfMines, ref totalCells);
            }
        }
    }

    private void PopulateNearbyNumbers()
    {
        for (var i = 1; i <= RowCount; i++)
        {
            for (var j = 1; j <= ColumnCount; j++)
            {
                var cellViewModel = SelectCell(i, j)!;
                cellViewModel.Cell.NearByMines = CalculateNearbyMines(i, j);
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
                var cellViewModel = SelectCell(i, j);
                if (cellViewModel is not null && cellViewModel.Cell.IsMine) count += 1;
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