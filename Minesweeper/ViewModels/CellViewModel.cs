using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public CellViewModel(int row,
        int column,
        IRelayCommand<CellViewModel> leftClickCommand,
        IRelayCommand<CellViewModel> rightClickCommand)
    {
        Row = row;
        Column = column;
        LeftClickCommand = leftClickCommand;
        RightClickCommand = rightClickCommand;
    }

    public int Row { get; init; }

    public int Column { get; init; }

    public bool IsMine { get; set; }

    public int NearByMines { get; set; }

    [ObservableProperty] private bool _isFlag;

    [ObservableProperty] private bool _isClicked;

    public IRelayCommand<CellViewModel> LeftClickCommand { get; init; }
    
    public IRelayCommand<CellViewModel> RightClickCommand { get; init; }
 }