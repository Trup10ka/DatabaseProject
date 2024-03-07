namespace DbProject.Database.Data;

public readonly struct Column(
    string name, 
    ColumnType type
    ) 
{
    public string Name { get; } = name;
    
    public ColumnType Type { get; init; } = type;
}