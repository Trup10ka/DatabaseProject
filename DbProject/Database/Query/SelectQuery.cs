namespace DbProject.Database.Query;

public class SelectQuery(
    string tableName,
    string[]? columnNames,
    string? whereClause,
    string? groupBy,
    string? having,
    string? orderBy
    ) : RawQuery(tableName)
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
}