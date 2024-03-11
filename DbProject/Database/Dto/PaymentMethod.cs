namespace DbProject.Database.Dto;

/// <summary>
/// Payment method DTO for PaymentMethod table
/// </summary>
/// <param name="Name">Name of the payment method</param>
/// <param name="ID">Primary key</param>
public record PaymentMethod(
    string Name,
    int? ID = null
    );