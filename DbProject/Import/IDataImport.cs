namespace DbProject.Import;

/// <summary>
/// Interface for importing data from a file and later pushed into database if possible.
/// </summary>
public interface IDataImport
{
    List<List<string>>? ImportData();
}