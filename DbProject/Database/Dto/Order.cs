namespace DbProject.Database.Dto;

public record Order(
    int CustomerId,
    int PcTypeId,
    int EmployeeId,
    int PaymentMethodId,
    decimal Price,
    string OrderDate,
    int? ID = null
    );