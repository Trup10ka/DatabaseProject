using DbProject.Database.Data;

namespace DbProject.Database.Query;

/// <summary>
/// Super class for all queries to the database.
/// </summary>
/// <param name="tableName">Table name on which the query is to be executed</param>
public abstract class AbstractQuery(string tableName)
{
    protected string TableName { get; } = tableName;
    
    /// <summary>
    /// Builds up the SQL command to be executed.
    /// </summary>
    public abstract string SqlCommand { get; }

    /// <summary>
    /// Executes the query and returns the result.
    /// </summary>
    /// <returns>List of result rows - either how many rows where affected as one result row in a list, or with select all attributes</returns>
    public abstract List<ResultRow> ExecuteQuery();
}