using DbProject.Database.Data;

namespace DbProject.Database.Query;

public abstract class AbstractQuery(string tableName)
{
    protected string TableName { get; } = tableName;
    
    public abstract string SqlCommand { get; }

    public abstract List<ResultRow> ExecuteQuery();
}