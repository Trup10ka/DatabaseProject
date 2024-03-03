using System.Text.Json;
using DbProject.Config.Data;

namespace DbProject.Util;

public static class FileManagement
{
    private static readonly JsonSerializerOptions Options = new () { WriteIndented = true };
    
    public static void CreateDirIfNotExists(string exportPath)
    {
        if (!Directory.Exists(exportPath))
            Directory.CreateDirectory(exportPath);
    }
    
    public static bool CopyTemplateConfigIfNotExists(string configPath)
    {
        if (File.Exists(configPath)) return true;
        
        File.WriteAllText(
            configPath, 
            JsonSerializer.Serialize(new TemplateConfig(), Options)
            );
        return false;
    }
}