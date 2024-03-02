namespace DbProject.Config.Data;

public record Config(
    string Host,
    string Username,
    string Password,
    short? Port = null,
    string? DbName = null
) : IConfig;