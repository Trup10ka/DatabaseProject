using DbProject.Database.Data;
using DbProject.Database.Util;
using Microsoft.Data.SqlClient;

namespace DbProject.Database.Query;

public class SelectQuery(
    string tableName,
    string[]? columnNames = null,
    string? whereClause = null,
    string? groupBy = null,
    string? having = null,
    string? orderBy = null
    ) : AbstractQuery(tableName)
{
    public override string SqlCommand
    {
        get
        {
            var columns = columnNames is null ? "*" : string.Join(", ", columnNames);
            var where = whereClause is null ? "" : $"WHERE {whereClause}";
            var group = groupBy is null ? "" : $"GROUP BY {groupBy}";
            var havingClause = having is null ? "" : $"HAVING {having}";
            var order = orderBy is null ? "" : $"ORDER BY {orderBy}";
            return $"SELECT {columns} FROM {TableName} {where} {group} {havingClause} {order}";
        }
    }

    public override List<ResultRow> ExecuteQuery()
    {
        using var sqlConnection = ConnectionManager.CreateConnection();
        sqlConnection.Open();
        var sqlCommand = new SqlCommand(SqlCommand, sqlConnection);
        var result = new List<ResultRow>();

        try
        {
          var reader = sqlCommand.ExecuteReader();
           while (reader.Read())
           {
               var row = new ResultRow(new List<string>());
               for (var i = 0; i < reader.FieldCount; i++)
               {
                   row.ColumnValue!.Add(reader[i].ToString() ?? string.Empty);
               }
               result.Add(row);
           }  
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
        return result;
    }
}