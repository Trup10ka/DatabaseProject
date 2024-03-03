using Microsoft.Data.SqlClient;

namespace DbProject.Database.Query;

public abstract class RawQuery(string tableName) : IQuery
{
    
    protected string TableName { get; } = tableName;
    
    public abstract string SqlCommand { get; }

    public virtual void Execute(SqlConnection sqlConnection)
    {
        using var sqlCommand = new SqlCommand(SqlCommand, sqlConnection);
        sqlCommand.ExecuteNonQuery();
    }
}