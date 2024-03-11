namespace DbProject.Database.Dto;

/// <summary>
/// DTO for Customer table
/// </summary>
/// <param name="Name">Customers name</param>
/// <param name="Surname">Customers surname</param>
/// <param name="Gender">Customers gender</param>
/// <param name="ID">Customers primary key</param>
public record Customer(
    string? Name = null,
    string? Surname = null,
    int? Gender = null,
    int? ID = null
    );