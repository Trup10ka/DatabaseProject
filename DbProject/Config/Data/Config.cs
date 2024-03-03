namespace DbProject.Config.Data;

public record Config(
    string Host,
    string Username,
    string Password,
    short? Port = null,
    string? DbName = null
)
{
    public override string ToString()
    {
        return "Host: " + Host + "\n" +
               "Username: " + Username + "\n" +
               "Password: " + Password + "\n" +
               "Port: " + Port + "\n" +
               "DbName: " + DbName + "\n";
    }
}