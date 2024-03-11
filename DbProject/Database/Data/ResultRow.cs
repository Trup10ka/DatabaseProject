namespace DbProject.Database.Data;

/// <summary>
/// All the columns of a single row of a result set.
/// </summary>
/// <param name="ColumnValue"></param>
/// <param name="RowsAffected"></param>
public record ResultRow(
    List<string>? ColumnValue = null,
    int RowsAffected = 0
)
{
    public override string ToString()
    {
        return ColumnValue != null ? $"{string.Join(", ", ColumnValue)}, RowsAffected: {RowsAffected}" : $"RowsAffected: {RowsAffected}";
    }
}