using System.Globalization;
using DbProject.Cli;
using DbProject.Config.Loader;
using DbProject.Database;
using DbProject.Database.Dao;
using DbProject.Database.Dto;
using DbProject.Database.Service;
using DbProject.Database.Util;
using DbProject.Import;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using static DbProject.Database.Util.ConnectionManager;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject;

public class DbClient
{
    private CliClient CliClient { get; }
    
    private Configuration Config { get; }
    
    public IOrdersService OrdersService => new DbOrdersService(OrdersTable);
    
    public ICustomerService CustomerService => new DbCustomerService(CustomerTable);
    
    private IDataImport DataImport => new CSVDataImport();
    
    private static Table CustomerTable => new CustomerTable();
    
    private Table OrdersTable => new OrdersTable();
    
    private Table EmployeeTable => new EmployeeTable();
    
    
    private DbClient(Configuration config, CliClient cliClient)
    {
        Config = config;
        CliClient = cliClient;
    }

    public void Start()
    {
        CliClient.PairWithDbClient(this);
        ConnectionManager.Config = Config;
        CliClient.Start();
    }
    
    public static bool TestConnection()
    {
        using var sqlConnection = CreateConnection();
        try
        {
            sqlConnection.Open();
            sqlConnection.Close();
        }
        catch (SqlException)
        {
            return false;
        }
        return true;
    }
    
    public Customer CreateNewCustomer()
    {
        CliClient.Logger.LogInformation("Enter customer name");
        var name = Console.ReadLine()!;
        CliClient.Logger.LogInformation("Enter customer surname");
        var address = Console.ReadLine()!;
        CliClient.Logger.LogInformation("Enter customer gender (0 = F/ 1 = M)");
        var gender = Console.ReadLine()!;
        if (!int.TryParse(gender, out var genderAsBool))
        {
            CliClient.Logger.LogError("Invalid input. Please enter 0 or 1 for gender");
        }
        return new Customer(
            Name: name,
            Surname: address,
            Gender: genderAsBool
        );
    }
    
    public Order? CreateNewOrder()
    {
        CliClient.Logger.LogInformation("Enter order total");
        var total = Console.ReadLine()!;
        if (!decimal.TryParse(total, out var totalAsDecimal))
        {
            CliClient.Logger.LogError("Invalid input. Please enter a number for total");
            return null;
        }
        CliClient.Logger.LogInformation("Enter customer full name, separated by a space ('John Wick')");
        var input = Console.ReadLine()!;
        var name = input.Split(' ')[0];
        var surname = input.Split(' ')[1];
        var customer = CustomerService.GetCustomerByNameAndSurname(name, surname);
        
        CliClient.Logger.LogInformation("Enter pc type - 1 to 5");
        var pcType = Console.ReadLine()!;
        if (!int.TryParse(pcType, out var pcTypeAsInt)) CliClient.Logger.LogError("Invalid input. Please enter a number for pc type");
        if (pcTypeAsInt is < 1 or > 5) CliClient.Logger.LogError("Invalid input. Please enter a number between 1 and 5 for pc type");
        
        var numberOfEmployees = Database.Util.Util.GetNumberOfEmployees();
        var randomEmployeeId = new Random().Next(1, numberOfEmployees);
        CliClient.Logger.LogInformation("Enter paymethod - cash, credit card, debit card, pay pal, google pay");
        var inputPaymentMethod = Console.ReadLine()!;
        var paymentMethod = Database.Util.Util.ResolvePaymentMethod(inputPaymentMethod);
        var orderDate = DateTime.Now.ToString(CultureInfo.InvariantCulture);

        return new Order(
            customer.ID!.Value,
            pcTypeAsInt,
            randomEmployeeId,
            paymentMethod,
            totalAsDecimal,
            OrderDate: orderDate
            );
    }
    
    public Customer UpdateCustomer()
    {
        CliClient.Logger.LogInformation("Enter customer full name, separated by a space ('John Wick')");
        var input = Console.ReadLine()!;
        if (string.IsNullOrEmpty(input))
        {
            CliClient.Logger.LogError("Invalid input. Please enter a name and surname");
            return new Customer();
        }
        var name = input.Split(' ')[0];
        var surname = input.Split(' ')[1];
        var customer = CustomerService.GetCustomerByNameAndSurname(name, surname);
        CliClient.Logger.LogInformation("""
                                        1. Name
                                        2. Surname
                                        3. Gender
                                        """);
        var inputOption = Console.ReadLine()!;
        if (!int.TryParse(inputOption, out var optionAsInt))
        {
            CliClient.Logger.LogError("Invalid input. Please enter a number");
        }

        switch (optionAsInt)
        {
            case 1:
                CliClient.Logger.LogInformation("Enter new name");
                var newName = Console.ReadLine()!;
                return new Customer(Name: newName, ID: customer.ID);
            case 2:
                CliClient.Logger.LogInformation("Enter new surname");
                var newSurname = Console.ReadLine()!;
                return new Customer(Surname: newSurname, ID: customer.ID);
            case 3:
                CliClient.Logger.LogInformation("Enter new gender (0 = F/ 1 = M)");
                var newGender = Console.ReadLine()!;
                return new Customer(Gender: newGender == "1" ? 1 : 0, ID: customer.ID);
            default:
                return new Customer();
        }
    }
    
    public int DeleteCustomer()
    {
        CliClient.Logger.LogInformation("Enter customer full name, separated by a space ('John Wick')");
        var input = Console.ReadLine()!;
        if (string.IsNullOrEmpty(input))
        {
            CliClient.Logger.LogError("Invalid input. Please enter a name and surname");
            return -1;
        }
        var name = input.Split(' ')[0];
        var surname = input.Split(' ')[1];
        var customer = CustomerService.GetCustomerByNameAndSurname(name, surname);
        return CustomerService.DeleteCustomer(customer.ID);
    }

    public void ImportData()
    {
        var data = DataImport.ImportData();
        if (data == null)
        {
            CliClient.Logger.LogWarning("No data to import");
            return;
        }
        switch (data[0][0].ToLower())
        {
            case "customer":
                foreach (var row in data.Skip(1))
                {
                    var customer = new Customer(
                        Name: row[0],
                        Surname: row[1],
                        Gender: int.Parse(row[2])
                    );
                    CustomerService.InsertCustomer(customer);
                }
                break;
        }
    }

    public int DeleteOrder()
    {
        CliClient.Logger.LogInformation("Enter order ID");
        var input = Console.ReadLine()!;
        if (!int.TryParse(input, out var orderId))
        {
            CliClient.Logger.LogError("Invalid input. Please enter a number for order ID");
        }
        return OrdersService.DeleteOrder(orderId);
    }
    
    /// <summary>
    /// Factory method for creating a new DbClient
    /// </summary>
    /// <returns>Instance of DbClient with config and CLI initialized</returns>
    public static DbClient CreateClient()
    {
        var configLoader = new JSONConfigHandler();
        var config = configLoader.LoadConfig();
        var cliClient = new CliClient(config);
        return new DbClient(config, cliClient);
    }
}