using DbProject.Database.Dao;
using DbProject.Database.Data;
using Microsoft.Data.SqlClient;
using static DbProject.Database.Util.ConnectionManager;

namespace DbProject.Database.Query;

public class UpdateQuery(
    string tableName,
    string columnName,
    string value,
    int? condition
    ) : AbstractQuery(tableName)
{

    public override string SqlCommand => $"UPDATE {TableName} SET {columnName} = {DetermineValueFormat()} WHERE {TableName}.id = {condition}";

    public override List<ResultRow> ExecuteQuery()
    {
        using var connection = CreateConnection();
        connection.Open();
        Console.WriteLine(SqlCommand);
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

    private string DetermineValueFormat()
    {
        if (int.TryParse(value, out var valueInt))
        {
            return value;
        }

        return decimal.TryParse(value, out var valueDecimal) ? value : $"'{value}'";
    }
}