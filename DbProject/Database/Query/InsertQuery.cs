using DbProject.Database.Data;
using Microsoft.Data.SqlClient;
using static DbProject.Database.Util.ConnectionManager;

namespace DbProject.Database.Query;

/// <summary>
/// Implementation of the abstract query class for an insert query.
///
/// Performs an insert into the database when calling ExecuteQuery.
/// </summary>
/// <param name="tableName">Table name on which query is to be called</param>
/// <param name="columnNames">All columns in which is meant to be inserted values</param>
/// <param name="values">Values for columns</param>
public class InsertQuery(
    string tableName,
    string[] columnNames,
    string[] values
    ) : AbstractQuery(tableName)
{
    public override string SqlCommand => 
        $"INSERT INTO {TableName} ({string.Join(", ", columnNames)}) VALUES ({AssembleValues(values)})";
    
    public override List<ResultRow> ExecuteQuery()
    {
        using var connection = CreateConnection();
        connection.Open();
        var command = new SqlCommand(SqlCommand, connection);
        var rowsAffected = 0;
        try
        {
           rowsAffected = command.ExecuteNonQuery(); 
        }
        catch (SqlException e)
        {
            Console.Error.WriteLine(e.Message);
        }
        
        return rowsAffected >= 1 ? [ new ResultRow(RowsAffected: rowsAffected)] : [ new ResultRow(RowsAffected: 0)];
    }
    
    private static string AssembleValues(IReadOnlyList<string> valuesArray)
    {
        var result = "";
        for (var i = 0; i < valuesArray.Count; i++)
        {
            if (int.TryParse(valuesArray[i], out var valueInt))
            {
                result += valueInt;
                continue;
            }

            if (decimal.TryParse(valuesArray[i], out var valueDecimal))
            {
                result += valueDecimal;
                continue;
            }
            result += $"'{valuesArray[i]}'";
            if (i != valuesArray.Count - 1) result += ", ";
        }
        return result;
    }
}