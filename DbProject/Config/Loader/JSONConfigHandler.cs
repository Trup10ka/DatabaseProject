using System.Text.Json;
using DbProject.Exceptions;
using static DbProject.Util.Paths;
using static DbProject.Util.FileManagement;

namespace DbProject.Config.Loader;

public class JSONConfigHandler : IConfigHandler
{
    public Data.Config LoadConfig()
    {
        var isConfigFileCreated = CopyTemplateConfigIfNotExists(ConfigPath);
        
        if (!isConfigFileCreated) throw new ConfigFileNotFoundException();
        
        var configContent = LoadFileContent(ConfigPath);

        if (!string.IsNullOrEmpty(configContent)) 
            return ParseConfig(configContent);
        
        CopyTemplateConfig(ConfigPath);
        throw new ConfigFileEmptyException();
    }

    public void SaveConfig(Data.Config config)
    {
        File.WriteAllText(
            ConfigPath,
            JsonSerializer.Serialize(config, IConfigHandler.Options)
            );
    }
    
    private static Data.Config ParseConfig(string configContent)
    {
        var config = JsonSerializer.Deserialize<Data.Config>(configContent)!;
        
        if (string.IsNullOrEmpty(config.Username)) throw new ConfigMandatoryFieldEmptyException("Username");
        if (string.IsNullOrEmpty(config.Password)) throw new ConfigMandatoryFieldEmptyException("Password");
        if (string.IsNullOrEmpty(config.Host)) throw new ConfigMandatoryFieldEmptyException("Host");

        return config;
    }
}