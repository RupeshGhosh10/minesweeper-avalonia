using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Minesweeper.Services;
using Minesweeper.Services.Interfaces;
using Minesweeper.ViewModels;
using Minesweeper.Views;

namespace Minesweeper;

public partial class App : Application
{
    public override void Initialize()
    {
        Services = ConfigureServices();
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    public new static App Current => (App)Application.Current!;
    
    public IServiceProvider Services { get; private set; } = null!;

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IGameService, GameService>();

        return services.BuildServiceProvider();
    }
}