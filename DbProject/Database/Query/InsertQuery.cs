using DbProject.Database.Data;
using Microsoft.Data.SqlClient;
using static DbProject.Database.ConnectionManager;

namespace DbProject.Database.Query;

public class InsertQuery(
    string tableName,
    string[] columnNames,
    string[] values
    ) : AbstractQuery(tableName)
{
    public override string SqlCommand => 
        $"INSERT INTO {TableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)})";
    
    public override List<ResultRow> ExecuteQuery()
    {
        using var connection = CreateConnection();
        using var command = new SqlCommand(SqlCommand, connection);
        var rowsAffected = command.ExecuteNonQuery();
        
        return rowsAffected >= 1 ? [ new ResultRow(RowsAffected: rowsAffected)] : [ new ResultRow(RowsAffected: 0)];
    }
}