using DbProject.Database.Dao;
using DbProject.Database.Data;
using DbProject.Database.Query;

namespace DbProject.Database.Util;

/// <summary>
/// CRUDUtil class provides all the CRUD operations for the Table class as extension methods.
///
/// <li>
///     <ul>Insert - inserts values provided on the tables columns</ul>
///     <ul>Update - updates the value of a column based on the id</ul>
///     <ul>Select - selects rows based on the where clause</ul>
///     <ul>Delete - deletes rows based on the where clause</ul>
/// </li>
/// All the CRUD operations return Int as a value for the number of rows affected, except for select which returns a list of ResultRow.
/// </summary>
public static class CRUDUtil
{
    /// <summary>
    /// Inserts values into the table based on the columns provided.
    /// </summary>
    /// <param name="table">Table in which the values are to be inserted</param>
    /// <param name="values">Values</param>
    /// <returns>Rows affected</returns>
    public static int Insert(this Table table, string[] values)
    {
        var insertQuery = new InsertQuery(table.Name, columnNames: table.Columns.ToStringArrayWithoutId(), values: values);
        return insertQuery.ExecuteQuery()[0].RowsAffected;
    }
    
    /// <summary>
    /// Updates the value of a column based on the column name and object id.
    /// </summary>
    /// <param name="table">Table of which the row is to be updated</param>
    /// <param name="find">Column which is to be updated in that table</param>
    /// <param name="value">New value</param>
    /// <param name="id">Id of the column record</param>
    /// <returns>Rows affected</returns>
    public static int Update(this Table table, Column find, string value, int? id)
    {
        var updateQuery = new UpdateQuery(table.Name, find.Name, value, id);
        return updateQuery.ExecuteQuery()[0].RowsAffected;
    }
    
    /// <summary>
    /// Select rows based on the where clause (returns all columns).
    /// </summary>
    /// <param name="table">Table which will be queried</param>
    /// <param name="whereClause">Condition</param>
    /// <returns>List of all result rows</returns>
    public static List<ResultRow> Select(this Table table, string whereClause)
    {
        var selectQuery = new SelectQuery(table.Name,  table.Columns.ToStringArrayWithId(), whereClause: whereClause);
        return selectQuery.ExecuteQuery();
    }
    
    /// <summary>
    /// Deletes rows based on the where clause.
    /// </summary>
    /// <param name="table">Table from which delete will be executed</param>
    /// <param name="whereClause">Condition</param>
    /// <returns>Rows affected</returns>
    public static int Delete(this Table table, string whereClause)
    {
        var deleteQuery = new DeleteQuery(table.Name, whereClause);
        return deleteQuery.ExecuteQuery()[0].RowsAffected;
    }
    
    /// <summary>
    /// Returns all Table columns as a string array with id.
    /// </summary>
    /// <param name="list">Table columns</param>
    /// <returns>String array filled with column names with id</returns>
    private static string[] ToStringArrayWithId(this IReadOnlyList<Column> list)
    {
        var array = new string[list.Count + 1];
        array[0] = "id";
        for (var i = 0; i < list.Count; i++)
        {
            array[i + 1] = list[i].Name;
        }
        return array;
    }
    
    /// <summary>
    /// Returns all Table columns as a string array without id.
    /// </summary>
    /// <param name="list">Table columns</param>
    /// <returns>String array filled with column names without id</returns>
    private static string[] ToStringArrayWithoutId(this IReadOnlyList<Column> list)
    {
        var array = new string[list.Count];
        for (var i = 0; i < list.Count; i++)
        {
            array[i] = list[i].Name;
        }
        return array;
    }
}