namespace DbProject.Database.Dto;

/// <summary>
/// Order DTO for Order table
/// </summary>
/// <param name="CustomerId">Customer foreign key</param>
/// <param name="PcTypeId">Pc type foreign key</param>
/// <param name="EmployeeId">Employee foreign key</param>
/// <param name="PaymentMethodId">Payment foreign key</param>
/// <param name="Price">Total price for order</param>
/// <param name="OrderDate">Order date</param>
/// <param name="ID">Order primary key</param>
public record Order(
    int CustomerId,
    int PcTypeId,
    int EmployeeId,
    int PaymentMethodId,
    decimal Price,
    string OrderDate,
    int? ID = null
    );