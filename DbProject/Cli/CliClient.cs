using DbProject.Exceptions;
using Microsoft.Extensions.Logging;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Cli;

public class CliClient(Configuration config)
{
    private Configuration Config { get; init; } = config;
    private ILogger? Logger { get; set; }
    
    public void Start()
    {
        InitializeLogger();
    }

    private void InitializeLogger()
    {
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        Logger = factory.CreateLogger("Main");

        if (Logger == null)
            throw new LoggerNotInitializedException();
    }
}