using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DBDefsLib;
using DBDefsLib.Structs;
using Spellwork2.Attributes;
using Spellwork2.Configuration;

namespace Spellwork2.ViewModels;

public partial class SetupWindowViewModel : ValidatedViewModel
{
    private static readonly Uri DbDefsUri = new("https://github.com/wowdev/WoWDBDefs/releases/latest/download/all.bdbd");
    private static readonly HttpClient DownloadClient = new();

    [ObservableProperty]
    public partial bool IsDownloadingDefs { get; set; }

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Db2Directory(ErrorMessage = "The directory must contain DB2 or DBC files")]
    [Required(ErrorMessage = "DB2/DBC files are required to run this application")]
    public partial string Db2FolderPath { get; set; }
    
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [FileExtensions(ErrorMessage = "The selected file must be a .bdbd file", Extensions = ".bdbd")]
    [Required(ErrorMessage = "DB definitions are required to parse the DB2 files")]
    public partial string DbDefsPath { get; set; }
    
    [ObservableProperty]
    public partial List<string> AvailableBuilds { get; set; }
    
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Please select a build from the list of available builds")]
    public partial string? SelectedBuild { get; set; }
    
    public SetupWindowViewModel()
    {
        AvailableBuilds = [];
        
        Db2FolderPath = ConfigurationMgr.Db2FolderPath;
        DbDefsPath = ConfigurationMgr.DbDefsPath;
        SelectedBuild = ConfigurationMgr.SelectedBuild;

        if (!string.IsNullOrWhiteSpace(Db2FolderPath))
            UpdateBuildList();
    }
    
    [RelayCommand]
    public async Task SaveCurrentSettings(WindowNotificationManager notificationManager)
    {
        ConfigurationMgr.Db2FolderPath = Db2FolderPath;
        ConfigurationMgr.DbDefsPath = DbDefsPath;
        ConfigurationMgr.SelectedBuild = SelectedBuild;
        
        await ConfigurationMgr.SaveConfigAsync();
        
        SaveSettings?.Invoke();
        SaveSettings = null;
    }

    public delegate void OnSaveSettings();

    public event OnSaveSettings? SaveSettings;

    [RelayCommand]
    public async Task DownloadDbDefs(WindowNotificationManager notificationManager)
    {
        IsDownloadingDefs = true;
        string fileName = Path.GetFileName(DbDefsUri.AbsolutePath);

        try
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            await using Stream downloadStream = await DownloadClient.GetStreamAsync(DbDefsUri);
            await using FileStream fs = File.OpenWrite(fileName);

            await downloadStream.CopyToAsync(fs);
            DbDefsPath = fs.Name;
            fs.Close();
            
            notificationManager.Show($"File '{fileName}' has been successfully downloaded", NotificationType.Success);

            UpdateBuildList();
        }
        catch (Exception)
        {
            notificationManager.Show("An error occured while trying to download DbDefs", NotificationType.Error);
        }
        finally
        {
            IsDownloadingDefs = false;
        }
    }

    [RelayCommand]
    public async Task SelectDb2Folder(Window window)
    {
        var folders = await window.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
        {
            Title = "Select DB2/DBC folder",
            AllowMultiple = false,
        });

        if (folders.Count == 0)
            return;

        Db2FolderPath = folders[0].Path.AbsolutePath;
    }
    
    [RelayCommand]
    public async Task SelectDbDefsFile(Window window)
    {
        var files = await window.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Select BDBD file",
            AllowMultiple = false,
            FileTypeFilter = [new FilePickerFileType("BDBD File") {Patterns = ["*.bdbd"]}]
        });

        if (files.Count == 0)
            return;

        DbDefsPath = files[0].Path.AbsolutePath;
    }
    
    public void UpdateBuildList()
    {
        if (!File.Exists(DbDefsPath))
        {
            SelectedBuild = null;
            return;
        }

        using FileStream fs = File.OpenRead(DbDefsPath);
        TableInfo table = BDBDReader.ReadSingle(fs, "Spell");
        VersionDefinitions[] versions = table.dbd.versionDefinitions;

        List<string> builds = [];
        foreach (VersionDefinitions version in versions)
        {
            foreach (BuildRange buildRange in version.buildRanges)
            {
                builds.Add(buildRange.minBuild.ToString());
                builds.Add(buildRange.maxBuild.ToString());
            }

            foreach (Build build in version.builds)
            {
                builds.Add(build.ToString());
            }
        }
        
        AvailableBuilds = builds.Distinct().OrderBy(x => x).ToList();
        
        if (SelectedBuild != null && !AvailableBuilds.Contains(SelectedBuild))
            SelectedBuild = null;
    }
}
