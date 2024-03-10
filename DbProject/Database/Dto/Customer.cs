namespace DbProject.Database.Dto;

public record Customer(
    string Name,
    string Surname,
    bool Gender,
    int? ID = null
    );