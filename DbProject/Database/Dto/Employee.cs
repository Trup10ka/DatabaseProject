namespace DbProject.Database.Dto;

/// <summary>
/// Employee DTO for Employee table
/// </summary>
/// <param name="Name">Employee name</param>
/// <param name="Surname">Employees surname</param>
/// <param name="EmployeeId">Employee custom ID - not the primary key of DB</param>
/// <param name="ID">Employee primary key</param>
public record Employee(
    string Name,
    string Surname,
    int EmployeeId,
    int? ID = null
    );