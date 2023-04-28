using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Minesweeper.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Content = new StartViewModel();
    }
    
    [ObservableProperty] 
    private ViewModelBase _content;

    [RelayCommand]
    private void StartGame()
    {
        Content = new GameViewModel();
    }
}