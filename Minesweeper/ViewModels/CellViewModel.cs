using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Minesweeper.Models;

namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public CellViewModel(int row, int column, bool isMine, IRelayCommand<CellViewModel> clickCommand)
    {
        Cell = new Cell(row, column, isMine);
        ClickCommand = clickCommand;
        Text = "";
        IsClicked = false;
    }

    public Cell Cell { get; init; }

    [ObservableProperty]
    private string _text;

    [ObservableProperty]
    private bool _isClicked;
    
    public IRelayCommand<CellViewModel> ClickCommand { get; init; }
}