using System;
using Avalonia.Controls;
using Spellwork2.ViewModels;

namespace Spellwork2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override async void OnOpened(EventArgs e)
    {
        try
        {
            base.OnOpened(e);
            
            // Don't invoke the loading logic while in design
            if (Design.IsDesignMode)
                return; 
            
            if (DataContext is MainViewModel vm)
            {
                vm.NotificationManager = NotificationManager;
                await vm.LoadStoragesAsync();
            }
        }
        catch (Exception)
        {
        }
    }
}