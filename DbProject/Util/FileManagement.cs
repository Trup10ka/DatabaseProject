using System.Text.Json;
using DbProject.Config.Data;

namespace DbProject.Util;

/// <summary>
/// Class responsible for managing files and directories.
/// </summary>
public static class FileManagement
{
    /// <summary>
    /// Json options for serialization.
    ///
    /// When writing, the output will be indented, in other words "pretty print". (default: false
    /// </summary>
    private static readonly JsonSerializerOptions JsonOptions = new () { WriteIndented = true };
    
    /// <summary>
    /// FileManagement stores a default TemplateConfig to be used when creating a new project in case of missing config file.
    /// </summary>
    private static readonly TemplateConfig TemplateConfig = new ();
    
    /// <summary>
    /// Creates a directory of specified name if it does not exist.
    /// </summary>
    /// <param name="exportPath">Name of the directory</param>
    public static void CreateDirIfNotExists(string exportPath)
    {
        if (!Directory.Exists(exportPath))
            Directory.CreateDirectory(exportPath);
    }
    
    /// <summary>
    /// Creates a config file with default values.
    /// </summary>
    /// <param name="configPath">Config path</param>
    public static void CopyTemplateConfig(string configPath)
    {
        File.WriteAllText(
            configPath, 
            JsonSerializer.Serialize(TemplateConfig, JsonOptions)
            );
    }
    
    /// <summary>
    /// Creates a config file with default values if it does not exist.
    /// </summary>
    /// <param name="configPath">Config path</param>
    /// <returns>Whether the file was created of not.</returns>
    public static bool CopyTemplateConfigIfNotExists(string configPath)
    {
        if (File.Exists(configPath)) return true;
        
        File.WriteAllText(
            configPath, 
            JsonSerializer.Serialize(TemplateConfig, JsonOptions)
            );
        return false;
    }
    
    public static string LoadFileContent(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch
        {
            return "";
        }
    }
}