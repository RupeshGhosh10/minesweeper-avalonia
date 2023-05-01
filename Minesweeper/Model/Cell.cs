namespace Minesweeper.Model;

public class Cell
{
    public int Row { get; init; }

    public int Column { get; init; }

    public bool IsMine { get; set; }

    public int NearByMines { get; set; }
}