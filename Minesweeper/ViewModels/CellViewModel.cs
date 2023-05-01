using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Minesweeper.Model;

namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public CellViewModel(int row,
        int column,
        IRelayCommand<CellViewModel> leftClickCommand,
        IRelayCommand<CellViewModel> rightClickCommand)
    {
        Cell = new Cell
        {
            Row = row,
            Column = column
        };

        LeftClickCommand = leftClickCommand;
        RightClickCommand = rightClickCommand;
    }

    public Cell Cell { get; init; }

    [ObservableProperty] private bool _isFlag;

    [ObservableProperty] private bool _isRevealed;

    public IRelayCommand<CellViewModel> LeftClickCommand { get; init; }

    public IRelayCommand<CellViewModel> RightClickCommand { get; init; }
}