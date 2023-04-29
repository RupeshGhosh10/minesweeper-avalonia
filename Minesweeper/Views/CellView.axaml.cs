using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Minesweeper.Views;

public partial class CellView : UserControl
{
    public CellView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}