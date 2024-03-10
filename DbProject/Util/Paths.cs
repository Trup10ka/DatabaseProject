namespace DbProject.Util;

/// <summary>
/// Static class for storing paths to files and directories.
/// </summary>
public static class Paths
{
    public static readonly string ConfigPath = 
        Path.Combine(Environment.CurrentDirectory, "config.json");
    
    public static readonly string ExportPath = 
        Path.Combine(Environment.CurrentDirectory, @"exports\");
}