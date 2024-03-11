using System.Text.Json;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Config.Loader;

/// <summary>
/// Interface for handling the config file (loading and saving).
/// </summary>
public interface IConfigHandler
{
    
    /// <summary>
    /// Config handler automatically provides JSON options for serialization.
    /// </summary>
    protected static readonly JsonSerializerOptions Options = new () { WriteIndented = true };
    
    /// <summary>
    /// Loads config file into a Config object.
    /// </summary>
    /// <returns></returns>
    Configuration LoadConfig();
    
    void SaveConfig(Configuration config);
}