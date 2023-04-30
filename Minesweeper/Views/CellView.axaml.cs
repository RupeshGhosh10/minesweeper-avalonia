using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Minesweeper.Views;

public partial class CellView : UserControl
{
    public CellView()
    {
        InitializeComponent();
        var cellButton = this.FindControl<Button>("CellButton");
        cellButton.AddHandler(PointerPressedEvent, CellButton_OnPointerPressed, RoutingStrategies.Tunnel);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void CellButton_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as IInputElement);
        if (point.Properties.IsRightButtonPressed)
        {
            
        }
    }
}