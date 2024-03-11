namespace DbProject.Exceptions;

/// <summary>
/// Occurs when a mandatory field in the config file is empty (for example password).
/// </summary>
/// <param name="fieldName">Name of the field that is missing</param>
public class ConfigMandatoryFieldEmptyException(string fieldName)
    : ApplicationException($"The field {fieldName} is mandatory and cannot be empty. Fill it in the config file and restart the application.");