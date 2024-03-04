using DbProject.Exceptions;
using Microsoft.Extensions.Logging;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Cli;

public class CliClient(Configuration config)
{
    private DbClient? DbClient { get; set; }
    
    private Configuration Config { get; init; } = config;
    private ILogger? Logger { get; set; }
    
    public void Start()
    {
        InitializeLogger();
        
        if (Logger == null) throw new LoggerNotInitializedException();
        if (DbClient == null) throw new DbClientNotInitialized();
        
        Logger.LogInformation("Starting CLI Client");
        Logger.LogInformation("Establishing connection to database");
        DbClient.ConnectToDatabase();

    }

    private void InitializeLogger()
    {
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        Logger = factory.CreateLogger("Main");
    }
    
    public void PairWithDbClient(DbClient dbClient)
    {
        DbClient = dbClient;
    }
}