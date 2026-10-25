namespace Spellwork2.Configuration;

public class ConfigSettings
{
    public string Db2FolderPath { get; set; } = string.Empty;
    public string DbDefsPath { get; set; } = string.Empty;
    public string? SelectedBuild { get; set; }
    public bool DarkModeEnabled { get; set; }
}
