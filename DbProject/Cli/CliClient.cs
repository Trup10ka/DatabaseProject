using DbProject.Exceptions;
using Microsoft.Extensions.Logging;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Cli;

public class CliClient(Configuration config)
{
    private DbClient? DbClient { get; set; }
    
    private Configuration Config { get; init; } = config;
    private ILogger Logger { get; set; } = null!;
    
    public void Start()
    {
        InitializeLogger();
        
        Logger.LogInformation("Starting CLI Client");
        Logger.LogInformation("Establishing connection to database");
        var testConnection = DbClient.TestConnection();
        Logger.LogInformation("Connection established: {testConnection}", testConnection);
    }

    private void InitializeLogger()
    {
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        if (Logger == null) throw new LoggerNotInitializedException();
        Logger = factory.CreateLogger("Main");
    }
    
    public void PairWithDbClient(DbClient dbClient)
    {
        if (DbClient == null) throw new DbClientNotInitialized();
        DbClient = dbClient;
    }
}