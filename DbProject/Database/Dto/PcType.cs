namespace DbProject.Database.Dto;

/// <summary>
/// PcType DTO for PcType table
/// </summary>
/// <param name="Name">Type name</param>
/// <param name="ID">Primary key</param>
public record PcType(
    string Name,
    int? ID = null
    );