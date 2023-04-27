using CommunityToolkit.Mvvm.ComponentModel;

namespace Minesweeper.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase _content;

    public MainWindowViewModel()
    {
        _content = new StartViewModel();
    }
}