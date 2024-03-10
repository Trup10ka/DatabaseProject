namespace DbProject.Database.Dto;

public record Employee(
    string Name,
    string Surname,
    int EmployeeId,
    int? ID = null
    );