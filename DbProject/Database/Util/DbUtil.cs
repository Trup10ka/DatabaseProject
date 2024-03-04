using Microsoft.Data.SqlClient;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Database.Util;

public static class DbUtil
{
    public static string AssembleConnectionString(Configuration config)
    {
        var builder = new SqlConnectionStringBuilder()
        {
            DataSource = config.Host,
            UserID = config.Username,
            Password = config.Password,
            TrustServerCertificate = true
        };
        
        return builder.ConnectionString;
    }
}