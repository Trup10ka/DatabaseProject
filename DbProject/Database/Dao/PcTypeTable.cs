namespace DbProject.Database.Dao;

public class PcTypeTable : Table
{
    public PcTypeTable() : base("pc_type")
    {
        Id();
        Varchar("type");
    }
}