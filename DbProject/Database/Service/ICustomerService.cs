using DbProject.Database.Dto;

namespace DbProject.Database.Service;

/// <summary>
/// Provides operations with Customers table in the database
/// </summary>
public interface ICustomerService
{
    int InsertCustomer(Customer customer);

    int UpdateCustomer(Customer customer);
    
    int DeleteCustomer(int? customerId);
     
    Customer GetCustomerByNameAndSurname(string name, string surname);
}