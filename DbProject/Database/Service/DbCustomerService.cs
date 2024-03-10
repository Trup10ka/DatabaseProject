using DbProject.Database.Dao;
using DbProject.Database.Dto;
using DbProject.Database.Util;

namespace DbProject.Database.Service;

public class DbCustomerService(Table customerTable) : ICustomerService
{
    public int InsertCustomer(Customer customer)
    {
        return customerTable.Insert([customer.Name, customer.Surname, customer.Gender.ToString()]);
    }

    public int UpdateCustomer(Customer customer)
    {
        if (customer.Gender != null)
        {
            return customerTable.Update(customerTable.Columns.Find(column => column.Name == "gender"), customer.Gender.ToString()!, customer.ID);
        }

        if (customer.Surname != null)
        {
            return customerTable.Update(customerTable.Columns.Find(column => column.Name == "surname"), customer.Surname!, customer.ID);
        }
        
        if (customer.Name != null)
        {
            return customerTable.Update(customerTable.Columns.Find(column => column.Name == "name"), customer.Name!, customer.ID);
        }
        
        Console.Error.WriteLine("No parameters to change were provided");
        return -1;
    }

    public int DeleteCustomer(int? customerId)
    {
        if (customerId != null)
        {
            return customerTable.Delete($"{customerTable.Name}.id = '{customerId}'");
        }

        Console.Error.WriteLine("No customer ID was provided");
        return -1;
    }

    public Customer GetCustomerByNameAndSurname(string name, string surname)
    {
        var result = customerTable.Select($"{customerTable.Name}.name = '{name}' AND {customerTable.Name}.surname = '{surname}'");
        var rowAttributes = result[0].ColumnValue!;

        try
        {
           var gender = 0;
           if (rowAttributes[3].Equals("true", StringComparison.CurrentCultureIgnoreCase))
           {
               gender = 1;
           }
           return new Customer(
               Name: rowAttributes[1],
               Surname: rowAttributes[2],
               Gender: gender,
               ID: int.Parse(rowAttributes[0])
               ); 
        }
        catch
        {
            return new Customer();
        }
    }
}