using static DbProject.Database.ConnectionManager;

namespace DbProject.Database.Query;

public abstract class RawQuery(string tableName) : IQuery
{
    
    protected string TableName { get; } = tableName;
    
    public abstract string SqlCommand { get; }

    public virtual void Execute()
    {
        using var sqlConnection = CreateConnection();
    }
}