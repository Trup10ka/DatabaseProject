using System.Text.Json;
using DbProject.Config.Data;

namespace DbProject.Util;

public static class FileManagement
{
    private static readonly JsonSerializerOptions JsonOptions = new () { WriteIndented = true };
    
    private static readonly TemplateConfig TemplateConfig = new ();
    
    public static void CreateDirIfNotExists(string exportPath)
    {
        if (!Directory.Exists(exportPath))
            Directory.CreateDirectory(exportPath);
    }
    
    public static void CopyTemplateConfig(string configPath)
    {
        File.WriteAllText(
            configPath, 
            JsonSerializer.Serialize(TemplateConfig, JsonOptions)
            );
    }
    
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
        return File.ReadAllText(path);
    }
}