using Microsoft.Data.SqlClient;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Database;

public static class ConnectionManager
{
   public static Configuration Config { get; set; } = null!;

   public static SqlConnection CreateConnection()
   {
      return new SqlConnection(AssembleConnectionString(Config));
   }
   
   private static string AssembleConnectionString(Configuration config)
   {
        
      var builder = new SqlConnectionStringBuilder
      {
         DataSource = config.Host,
         UserID = config.Username,
         Password = config.Password,
         TrustServerCertificate = true
      };
        
      if (config.Port != null) builder.DataSource = $"{config.Host},{config.Port}";
        
      if (config.DbName != null) builder.InitialCatalog = config.DbName;
        
      return builder.ConnectionString;
   }
}