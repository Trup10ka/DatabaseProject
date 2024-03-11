namespace DbProject.Database.Data;

/// <summary>
/// Struct representing a Column in a table
/// </summary>
/// <param name="name">Column name</param>
/// <param name="type">Column type</param>
/// <param name="tableType">Table reference</param>
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