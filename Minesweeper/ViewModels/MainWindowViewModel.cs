namespace Minesweeper.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Content = new GameViewModel();
    }

    public ViewModelBase Content { get; set; }
}