namespace DbProject.Database.Data;

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