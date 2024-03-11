using System.Globalization;
using DbProject.Database.Dao;
using DbProject.Database.Dto;
using DbProject.Database.Util;

namespace DbProject.Database.Service;

/// <summary>
/// Database orders service implementation
/// </summary>
/// <param name="ordersTable">Orders table object</param>
public class DbOrdersService(Table ordersTable) : IOrdersService
{
    public int InsertNewOrder(Order order)
    {
        return ordersTable.Insert([
            order.CustomerId.ToString(), order.EmployeeId.ToString(), order.PcTypeId.ToString(), order.PaymentMethodId.ToString(),
            order.Price.ToString(CultureInfo.InvariantCulture), order.OrderDate
        ]);
    }

    public int DeleteOrder(int? orderId)
    {
        return ordersTable.Delete($"{ordersTable}.id = {orderId}");
    }
}