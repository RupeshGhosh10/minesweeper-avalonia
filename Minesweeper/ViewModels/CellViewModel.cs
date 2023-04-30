namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public CellViewModel(int row, int column, bool isMine)
    {
        Row = row;
        Column = column;
        IsMine = isMine;
    }
    
    public int Row { get; init; }

    public int Column { get; init; }

    public bool IsMine { get; init; }
}