using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Spellwork2.Configuration;
using Spellwork2.ViewModels;
using Spellwork2.Views;

namespace Spellwork2;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            MainViewModel mainWindowViewModel = new();
            MainWindow mainWindow = new()
            {
                DataContext = mainWindowViewModel
            };
            
            if (!File.Exists("config.json") || !ConfigurationMgr.LoadConfig())
            {
                SetupWindowViewModel setupViewModel = new();
                SetupWindowView setupWindow = new()
                {
                    DataContext = setupViewModel
                };
                
                setupViewModel.SaveSettings += () =>
                {
                    desktop.MainWindow = mainWindow;
                    desktop.MainWindow.Show();
                    setupWindow.Close();
                };
                
                desktop.MainWindow = setupWindow;
            }
            else
            {
                desktop.MainWindow = mainWindow;
            }

        }

        base.OnFrameworkInitializationCompleted();
    }
}