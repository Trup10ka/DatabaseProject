namespace DbProject.Database.Dto;

public record Order(
    int CustomerId,
    int PcTypeId,
    int EmployeeId,
    int PaymentMethodId,
    decimal Price,
    DateTime OrderDate,
    int? ID = null
    );