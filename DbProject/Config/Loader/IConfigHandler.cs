using System.Text.Json;
using DbProject.Config.Data;

namespace DbProject.Config.Loader;

public interface IConfigHandler
{
    protected static readonly JsonSerializerOptions Options = new () { WriteIndented = true };
    
    Data.Config LoadConfig();
    
    void SaveConfig(Data.Config config);
}