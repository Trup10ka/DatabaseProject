using DbProject.Config.Data;

namespace DbProject.Config.Loader;

public interface IConfigHandler
{
    Data.Config LoadConfig();
    
    void SaveConfig(IConfig config);
}