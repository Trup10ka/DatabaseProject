namespace DbProject.Database.Dao;

public class EmployeeTable : Table
{
    public EmployeeTable() : base("employee")
    {
        Varchar("name");
        Varchar("surname");
        Int("employee_id");
    }
}