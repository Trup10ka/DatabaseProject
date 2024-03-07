namespace DbProject.Database.Query;

public class InsertQuery(
    string tableName,
    string[] columnNames,
    string[] values
    ) : RawQuery(tableName)
{
    public override string SqlCommand => 
        $"INSERT INTO {TableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)})";
}