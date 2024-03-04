using DbProject.Cli;
using DbProject.Config.Loader;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject;

public class DbClient
{
    private CliClient CliClient { get; }
    
    private Configuration Config { get; init; }
    
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
        CliClient.Start();
    }

    public static DbClient CreateClient()
    {
        var configLoader = new JSONConfigHandler();
        var config = configLoader.LoadConfig();
        var cliClient = new CliClient(config);
        return new DbClient(config, configLoader, cliClient);
    }
}