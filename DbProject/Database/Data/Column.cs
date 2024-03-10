namespace DbProject.Database.Data;

public readonly struct Column(
    string name, 
    ColumnType type,
    Type? tableType = null
    ) 
{
    
    public string Name { get; } = name;
    
    public ColumnType Type { get; init; } = type;
    
    public Type? TableType { get; init; } = tableType;
}