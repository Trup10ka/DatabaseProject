using DbProject.Database.Data;
using Microsoft.Data.SqlClient;
using static DbProject.Database.Util.ConnectionManager;

namespace DbProject.Database.Query;

public class DeleteQuery(
    string tableName,
    string whereClause
    ) : AbstractQuery(tableName)
{

    public override string SqlCommand => $"DELETE FROM {TableName} WHERE {whereClause}";

    public override List<ResultRow> ExecuteQuery()
    {
        using var connection = CreateConnection();
        connection.Open();
        using var command = new SqlCommand(SqlCommand, connection);
        var rowsAffected = 0;
        try
        { 
            rowsAffected = command.ExecuteNonQuery(); 
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
        
        
        return rowsAffected >= 1 ? [ new ResultRow(RowsAffected: rowsAffected)] : [ new ResultRow(RowsAffected: 0)];
    }
}