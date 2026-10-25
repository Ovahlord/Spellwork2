using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Selection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spellwork2.Configuration;
using Spellwork2.DBC;
using NotificationType = Avalonia.Controls.Notifications.NotificationType;

namespace Spellwork2.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public FlatTreeDataGridSource<SpellInfoViewModel> SpellInfoSource { get; set;  }
    public ObservableCollection<ViewModelBase> SpellInfoFilters { get; set; } = [];
    public WindowNotificationManager? NotificationManager { get; set; }
    
    [ObservableProperty]
    public partial bool IsLoadingData { get; set; } = false;
    
    [ObservableProperty]
    public partial SpellInfoViewModel? SelectedSpellInfo { get; set; }
    
    [ObservableProperty]
    public partial string SpellInfoHeader { get; set; } = string.Empty;

    [ObservableProperty] 
    public partial string SpellIdOrNameFilter { get; set; } = string.Empty;
    
    public MainViewModel()
    {
        SpellInfoSource = new FlatTreeDataGridSource<SpellInfoViewModel>([])
        {
            Columns =
            {
                new TextColumn<SpellInfoViewModel, int>("SpellId", x => x.SpellId, new GridLength(80)),
                new TextColumn<SpellInfoViewModel, string>("Difficulty", x => x.DifficultyName, new GridLength(1, GridUnitType.Auto)),
                new TextColumn<SpellInfoViewModel, string>("Name", x => x.FullName, new GridLength(200)),
            },
        };

        BuildDataGridFilter();
        
        SpellInfoSource.RowSelection?.SelectionChanged += RowSelectionOnSelectionChanged;
    }

    private void RowSelectionOnSelectionChanged(object? sender, TreeSelectionModelSelectionChangedEventArgs<SpellInfoViewModel> e)
    {
        if (e.SelectedItems.Count <= 0)
            SelectedSpellInfo = null;
        else if (e.SelectedItems.Count == 1)
            SelectedSpellInfo = e.SelectedItems[0];
    }

    [RelayCommand]
    public void AddSpellInfoFilter()
    {
        SpellInfoFilters.Add(new SpellInfoFilterViewModel());
    }

    [RelayCommand]
    public void RemoveSpellInfoFilter(SpellInfoFilterViewModel  spellInfoFilter)
    {
        SpellInfoFilters.Remove(spellInfoFilter);
    }

    partial void OnSelectedSpellInfoChanged(SpellInfoViewModel? value)
    {
        if (value == null)
            return;
        
        SpellInfoHeader = $"ID: {value.SpellId} - {value.FullName}";
    }

    partial void OnSpellIdOrNameFilterChanged(string value)
    {
        SpellInfoSource.RefreshFilter();
    }

    private void BuildDataGridFilter()
    {
        SpellInfoSource.Filter(spellInfo =>
        {
            if (string.IsNullOrWhiteSpace(SpellIdOrNameFilter))
                return true;
            
            if (int.TryParse(SpellIdOrNameFilter, out int spellId))
                if (spellInfo.SpellId == spellId)
                    return true;
            
            if (!string.IsNullOrWhiteSpace(spellInfo.Name))
                if (spellInfo.Name.Contains(SpellIdOrNameFilter, StringComparison.OrdinalIgnoreCase))
                    return true;
            
            return false;
        });
    }
    
    public async Task LoadStoragesAsync()
    {
        if (string.IsNullOrWhiteSpace(ConfigurationMgr.Db2FolderPath) || !Directory.Exists(ConfigurationMgr.Db2FolderPath))
        {
            NotificationManager?.Show("Invalid DB2/DBC path specified. Please check your settings", NotificationType.Error);
            return;
        }
        
        if (!File.Exists(ConfigurationMgr.DbDefsPath))
        {
            NotificationManager?.Show("Unable to locate DbDefs file. Please check your settings", NotificationType.Error);
            return;
        }
        
        try
        {
            IsLoadingData = true;

            Stopwatch stopwatch = Stopwatch.StartNew();
            
            await DbcMgr.LoadStoragesAsync();
            
            // ==== Building SpellInfo data ==== /
            if (DbcMgr.SpellMiscStore == null)
            {
                DbcMgr.ClearStorages();
                return;
            }

            ConcurrentBag<SpellInfoViewModel> spellInfos = new();
            
            await Task.Run(() =>
            {
                Parallel.ForEach(DbcMgr.SpellMiscStore.Values, spellMiscRow =>
                {
                    spellInfos.Add(new SpellInfoViewModel(spellMiscRow, this));
                });
            });
            
            SpellInfoSource.Items = spellInfos
                .OrderBy(s => s.SpellId)
                .ThenBy(s => s.DifficultyId);
            
            // Db2 Data are no longer needed.
            DbcMgr.ClearStorages();
            
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
        catch (Exception ex)
        {
            NotificationManager?.Show("An error occured while loading", NotificationType.Error);
            Console.WriteLine(ex);
        }
        finally
        {
            IsLoadingData = false;
        }
    }
}
