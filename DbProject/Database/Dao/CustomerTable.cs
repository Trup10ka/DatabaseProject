
namespace DbProject.Database.Dao;

public class CustomerTable : Table
{
    public CustomerTable() : base("customer")
    {
        Varchar("name");
        Varchar("surname");
        Bit("gender");
    }
}