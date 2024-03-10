using DbProject.Database.Dao;
using DbProject.Database.Data;
using DbProject.Database.Query;

namespace DbProject.Database.Util;

public static class CRUDUtil
{
    public static int Insert(this Table table, string[] values)
    {
        var insertQuery = new InsertQuery(table.Name, columnNames: table.Columns.ToStringArray(), values: values);
        return insertQuery.ExecuteQuery()[0].RowsAffected;
    }
    
    public static int Update(this Table table, Column find, string value, int? id)
    {
        var updateQuery = new UpdateQuery(table.Name, find.Name, value, id);
        return updateQuery.ExecuteQuery()[0].RowsAffected;
    }
    
    public static List<ResultRow> Select(this Table table, string whereClause)
    {
        var selectQuery = new SelectQuery(table.Name,  table.Columns.ToStringArray(), whereClause: whereClause);
        return selectQuery.ExecuteQuery();
    }
    
    public static int Delete(this Table table, string whereClause)
    {
        var deleteQuery = new DeleteQuery(table.Name, whereClause);
        return deleteQuery.ExecuteQuery()[0].RowsAffected;
    }
    
    private static string[] ToStringArray(this IReadOnlyList<Column> list)
    {
        var array = new string[list.Count + 1];
        array[0] = "id";
        for (var i = 0; i < list.Count; i++)
        {
            array[i + 1] = list[i].Name;
        }
        return array;
    }
}