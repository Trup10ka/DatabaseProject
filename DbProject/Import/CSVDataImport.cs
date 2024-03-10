using static DbProject.Util.FileManagement;

namespace DbProject.Import;

public class CSVDataImport : IDataImport
{
    public List<List<string>>? ImportData()
    {
        var fileContent = LoadFileContent("import.csv");
        if (fileContent == "")
        {
            return null;
        }
        var lines = fileContent.Split("\n");
        return lines.Select(line => line.Trim('\r').Split(",").ToList()).ToList();
    }
}