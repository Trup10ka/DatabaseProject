namespace DbProject.Util;

public static class Paths
{
    public static readonly string ConfigPath = 
        Path.Combine(Environment.CurrentDirectory, "config.json");
    
    public static readonly string ExportPath = 
        Path.Combine(Environment.CurrentDirectory, @"exports\");
}