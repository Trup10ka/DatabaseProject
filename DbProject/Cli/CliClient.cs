using Microsoft.Extensions.Logging;
using Configuration = DbProject.Config.Data.Config;

namespace DbProject.Cli;

public class CliClient(Configuration config)
{
    private DbClient DbClient { get; set; } = null!;
    
    
    private Configuration Config { get; init; } = config;
    
    public ILogger Logger { get; private set; } = null!;
    
    public void Start()
    {
        InitializeLogger();
        
        Logger.LogInformation("Starting CLI Client");
        Logger.LogInformation("Establishing connection to database");
        var testConnection = DbClient.TestConnection();
        Logger.LogInformation("Connection established: {testConnection}", testConnection);

        if (testConnection)
        {
            while (true)
            {
                PrintOutOptions(); 
                ListenForInput();
            }
        }

        Logger.LogError("Connection to database failed. Exiting...");
        Environment.Exit(1);
    }
    
    private void PrintOutOptions()
    {
        Logger.LogInformation("""
                              1. Insert new customer
                              2. Insert new order
                              3. Update customer
                              4. Delete customer
                              5. Delete order
                              6. Exit
                              """);
    }
    
    private void ListenForInput()
    {
        var input = Console.ReadLine();
        if (input != null)
            ProcessInput(input);
    }
    
    private void ProcessInput(string? input)
    {
        if (!int.TryParse(input, out var inputAsInt))
        {
            Logger.LogError("Invalid input. Please enter a number");
            return;
        }

        switch (inputAsInt)
        {
            case 1:
            {
                var customer = DbClient.CreateNewCustomer();
                var result = DbClient.CustomerService.InsertCustomer(customer);
                if (result > 0)
                {
                    Logger.LogInformation("Successful");
                    return;
                }
                Logger.LogError("Failed");
                break;
            }
            case 2:
            {
                var order = DbClient.CreateNewOrder();
                if (order == null) return;
                var result = DbClient.OrdersService.InsertNewOrder(order);
                if (result > 0)
                {
                    Logger.LogInformation("Successful");
                    return;
                }
                Logger.LogError("Failed");
                break;
            }
            case 3:
            {
                var customer = DbClient.UpdateCustomer();
                var result = DbClient.CustomerService.UpdateCustomer(customer);
                if (result > 0)
                {
                    Logger.LogInformation("Successful");
                    return;
                }
                Logger.LogError("Failed");
                break;
            }
            case 4:
            {
                var result = DbClient.DeleteCustomer();
                if (result > 0)
                {
                    Logger.LogInformation("Successful");
                    return;
                }
                Logger.LogError("Failed");
                break;
            }
            case 5:
            {
                var result = DbClient.DeleteOrder();
                if (result > 0)
                {
                    Logger.LogInformation("Successful");
                    return;
                }
                Logger.LogError("Failed");
                break;
            }
            case 6:
                Environment.Exit(0);
                break;
            default:
                Logger.LogError("Invalid input. Please enter a number between 1 and 6");
                break;
        }
    }
    
    
    private void InitializeLogger()
    {
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        Logger = factory.CreateLogger("Main");
    }
    
    public void PairWithDbClient(DbClient dbClient)
    {
        DbClient = dbClient;
    }
}