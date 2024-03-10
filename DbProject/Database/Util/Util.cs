using DbProject.Database.Query;

namespace DbProject.Database.Util;

public static class Util
{
    public static int GetNumberOfEmployees()
    {
        var selectQuery = new SelectQuery("employee", ["COUNT(*)"]);
        return int.Parse(selectQuery.ExecuteQuery()[0].ColumnValue![0]);
    }
    
    public static int ResolvePaymentMethod(string paymentMethod)
    {
        return paymentMethod.ToLower() switch
        {
            "cash" => 1,
            "credit card" => 2,
            "debit card" => 3,
            "pay pal" => 4,
            "google pay" => 5,
            _ => 0
        };
    }
}