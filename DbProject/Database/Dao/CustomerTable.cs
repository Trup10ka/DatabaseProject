
namespace DbProject.Database.Dao;

public class CustomerTable : Table
{
    public CustomerTable() : base("customer")
    {
        Id();
        Varchar("name");
        Varchar("surname");
        Bit("gender");
    }
}