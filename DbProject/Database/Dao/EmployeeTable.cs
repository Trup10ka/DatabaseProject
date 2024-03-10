namespace DbProject.Database.Dao;

public class EmployeeTable : Table
{
    public EmployeeTable() : base("employee")
    {
        Id();
        Varchar("name");
        Varchar("surname");
        Int("employee_id");
    }
}