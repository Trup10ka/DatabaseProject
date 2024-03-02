using DbProject.Exceptions;
using Microsoft.Extensions.Logging;

namespace DbProject.Cli;

public class CliClient
{
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