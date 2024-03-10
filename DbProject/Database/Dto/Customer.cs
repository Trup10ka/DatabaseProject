namespace DbProject.Database.Dto;

public record Customer(
    string? Name = null,
    string? Surname = null,
    int? Gender = null,
    int? ID = null
    );