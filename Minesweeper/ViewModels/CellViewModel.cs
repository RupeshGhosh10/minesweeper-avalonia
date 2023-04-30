namespace Minesweeper.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public int Row { get; init; }

    public int Column { get; init; }

    public bool IsMine { get; init; }
}