using Microsoft.Data.SqlClient;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Database.Util;

/// <summary>
/// ConnectionManager class provides a method to create a connection to the database.
///
/// Also provides a method to assemble the connection string based on the configuration provided.
/// </summary>
public static class ConnectionManager
{
   /// <summary>
   /// Config loaded by the application.
   /// </summary>
   public static Configuration Config { get; set; } = null!;

   /// <summary>
   /// Creates new connection to the database using the config provided.
   /// </summary>
   /// <returns>New SQL connection</returns>
   public static SqlConnection CreateConnection()
   {
      return new SqlConnection(AssembleConnectionString(Config));
   }
   
   /// <summary>
   /// Creates a new connection string based on the configuration provided.
   /// </summary>
   /// <param name="config">Configuration</param>
   /// <returns>Connection string</returns>
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