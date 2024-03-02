using System.Text.Json;
using DbProject.Config.Data;
using static DbProject.Util.Paths;

namespace DbProject.Util;

public static class FileManagement
{
    private static readonly JsonSerializerOptions Options = new () { WriteIndented = true };
    
    public static void CreateDirIfNotExists()
    {
        if (!Directory.Exists(ExportPath))
            Directory.CreateDirectory(ExportPath);
    }
    
    public static bool CopyTemplateConfigIfNotExists()
    {
        if (File.Exists(ConfigPath)) return true;
        
        File.WriteAllText(
            ConfigPath, 
            JsonSerializer.Serialize(new TemplateConfig(), Options)
            );
        return false;
    }
}