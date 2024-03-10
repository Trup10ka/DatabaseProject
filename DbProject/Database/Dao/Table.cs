using DbProject.Database.Data;

namespace DbProject.Database.Dao;

public class Table(string name)
{
    
    public string Name { get; init; } = name;
    public List<Column> Columns { get; } = [];
    
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
    
    private void RegisterIDColumn(string name)
    {
        var column = new Column(name, ColumnType.INT);
    }
    
    protected void Id() => RegisterIDColumn("id");

    protected void Varchar(string name) => RegisterColumn(name, ColumnType.VARCHAR);
    
    protected void Int(string name) => RegisterColumn(name, ColumnType.INT);
    
    protected void Bit(string name) => RegisterColumn(name, ColumnType.BIT);
    
    protected void Date(string name) => RegisterColumn(name, ColumnType.DATE);
    
    protected void Float(string name) => RegisterColumn(name, ColumnType.FLOAT);
    
    protected void Reference(string name, Type tableType) => RegisterColumn(name, ColumnType.REFERENCE, tableType);
}