using DbProject.Database.Query;

namespace DbProject.Database.Util;

/// <summary>
/// Utility class for other second hand operations.
/// </summary>
public static class Util
{
    
    /// <summary>
    /// Queries the database to get the number of all employees in table.
    /// </summary>
    /// <returns>Number of employees</returns>
    public static int GetNumberOfEmployees()
    {
        var selectQuery = new SelectQuery("employee", ["COUNT(*)"]);
        return int.Parse(selectQuery.ExecuteQuery()[0].ColumnValue![0]);
    }
    
    /// <summary>
    /// Returns the payment method id for the given payment method as string.
    /// </summary>
    /// <param name="paymentMethod">Given payment method</param>
    /// <returns>Payment method ID from DB</returns>
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