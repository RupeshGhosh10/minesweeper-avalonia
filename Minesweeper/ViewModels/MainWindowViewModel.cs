namespace Minesweeper.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Content = new GameViewModel();
    }

    public ViewModelBase Content { get; set; }
}