using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Minesweeper.Helper;

namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public CellViewModel(int row, int column, IRelayCommand<CellViewModel> clickCommand)
    {
        Row = row;
        Column = column;
        ClickCommand = clickCommand;
    }

    public int Row { get; init; }

    public int Column { get; init; }

    public bool IsMine { get; set; }
    
    public int NearByMines { get; set; }

    [ObservableProperty] private bool _isClicked;

    public IRelayCommand<CellViewModel> ClickCommand { get; init; }
}