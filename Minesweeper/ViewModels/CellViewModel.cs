using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public CellViewModel(int row, int column, bool isMine, IRelayCommand<CellViewModel> clickCommand)
    {
        _row = row;
        _column = column;
        _isMine = isMine;
        ClickCommand = clickCommand;
        Text = "";
    }

    private int _row;

    private int _column;

    private bool _isMine;

    [ObservableProperty]
    private string _text;
    
    public IRelayCommand<CellViewModel> ClickCommand { get; init; }
}