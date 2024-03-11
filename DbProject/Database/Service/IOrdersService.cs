using DbProject.Database.Dto;

namespace DbProject.Database.Service;

/// <summary>
/// Provides manipulation with Orders table in database.
/// </summary>
public interface IOrdersService
{
    int InsertNewOrder(Order order);
    
    int DeleteOrder(int? orderId);
}