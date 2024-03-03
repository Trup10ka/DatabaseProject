namespace DbProject;

public static class Program
{
    public static void Main(string[] args)
    {
        var dbClient = DbClient.CreateClient();
        dbClient.Start();
    }
}