using Microsoft.Data.SqlClient;

namespace DbProject.Database.Query;

public interface IQuery
{
    
    string SqlCommand { get; }
    
    void Execute();
}