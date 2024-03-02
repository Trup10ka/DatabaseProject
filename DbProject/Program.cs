using DbProject.Cli;

namespace DbProject;

public static class Program
{
    public static void Main(string[] args)
    {
        var cli = new CliClient();
        cli.Start();
    }
}