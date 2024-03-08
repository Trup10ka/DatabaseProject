using DbProject.Cli;
using DbProject.Config.Loader;
using DbProject.Database;
using static DbProject.Database.ConnectionManager;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject;

public class DbClient
{
    private CliClient CliClient { get; }
    
    private Configuration Config { get; }
    
    private IConfigHandler ConfigHandler { get; }
    
    private DbClient(Configuration config, IConfigHandler configHandler, CliClient cliClient)
    {
        Config = config;
        ConfigHandler = configHandler;
        CliClient = cliClient;
    }

    public void Start()
    {
        CliClient.PairWithDbClient(this);
        ConnectionManager.Config = Config;
        CliClient.Start();
    }
    
    public bool ConnectToDatabase()
    {
        using var sqlConnection = CreateConnection();
        sqlConnection.Open();
        sqlConnection.Close();
        return true;
    }
    
    /// <summary>
    /// Factory method for creating a new DbClient
    /// </summary>
    /// <returns>Instance of DbClient with config and CLI initialized</returns>
    public static DbClient CreateClient()
    {
        var configLoader = new JSONConfigHandler();
        var config = configLoader.LoadConfig();
        var cliClient = new CliClient(config);
        return new DbClient(config, configLoader, cliClient);
    }
}