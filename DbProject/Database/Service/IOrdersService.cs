using DbProject.Database.Dto;

namespace DbProject.Database.Service;

public interface IOrdersService
{
    int InsertNewOrder(Order order);
    
    int DeleteOrder(int? orderId);
}