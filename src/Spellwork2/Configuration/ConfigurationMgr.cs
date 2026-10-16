using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spellwork2.Configuration;

public static class ConfigurationMgr
{
    private static ConfigSettings _settings;

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        IndentSize = 4,
        WriteIndented = true
    };

    public static string Db2FolderPath
    {
        get => _settings.Db2FolderPath;
        set => _settings.Db2FolderPath = value;
    }
    
    public static string DbDefsPath
    {
        get =>  _settings.DbDefsPath;
        set => _settings.DbDefsPath = value;
    }

    public static string? SelectedBuild
    {
        get => _settings.SelectedBuild;
        set => _settings.SelectedBuild = value;
    }

    static ConfigurationMgr()
    {
        _settings = new ConfigSettings();
    }
    
    public static bool LoadConfig()
    {
        if (!File.Exists("config.json"))
            return false;

        try
        {
            using FileStream fs = File.OpenRead("config.json");
            ConfigSettings? loadedSettings = JsonSerializer.Deserialize<ConfigSettings>(fs);
            if (loadedSettings == null)
                return false;

            _settings = loadedSettings;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static async Task SaveConfigAsync()
    {
        if (File.Exists("config.json"))
            File.Delete("config.json");
        
        await using FileStream fs = File.OpenWrite("config.json");
        await JsonSerializer.SerializeAsync(fs, _settings, SerializerOptions);
    }
}
