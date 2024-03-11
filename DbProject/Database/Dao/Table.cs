using DbProject.Database.Data;

namespace DbProject.Database.Dao;

/// <summary>
/// DAO representation of a table in the database.
///
/// <br></br>
///
/// When initializing a new table, the name of the table should be passed to the constructor, and in that constructor,
/// the columns of the table should be registered by calling methods as types
/// </summary>
/// <param name="name">Table name</param>
public class Table(string name)
{
    
    public string Name { get; } = name;
    
    /// <summary>
    /// All table columns
    /// </summary>
    public List<Column> Columns { get; } = [];
    
    /// <summary>
    /// Registers a column in the table
    /// </summary>
    /// <param name="name">Column name</param>
    /// <param name="type">Column type</param>
    private void RegisterColumn(string name, ColumnType type)
    {
        var column = new Column(name, type);
        Columns.Add(column);
    }
    
    private void RegisterColumn(string name, ColumnType type, Type reference)
    {
        var column = new Column(name, type, reference);
        Columns.Add(column);
    }
    
    private static void RegisterIDColumn(string name)
    {
        var column = new Column(name, ColumnType.INT);
    }
    
    protected static void Id() => RegisterIDColumn("id");

    protected void Varchar(string name) => RegisterColumn(name, ColumnType.VARCHAR);
    
    protected void Int(string name) => RegisterColumn(name, ColumnType.INT);
    
    protected void Bit(string name) => RegisterColumn(name, ColumnType.BIT);
    
    protected void Date(string name) => RegisterColumn(name, ColumnType.DATE);
    
    protected void Float(string name) => RegisterColumn(name, ColumnType.FLOAT);
    
    protected void Reference(string name, Type tableType) => RegisterColumn(name, ColumnType.REFERENCE, tableType);
}