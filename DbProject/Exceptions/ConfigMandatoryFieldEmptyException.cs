namespace DbProject.Exceptions;

public class ConfigMandatoryFieldEmptyException(string fieldName)
    : ApplicationException($"The field {fieldName} is mandatory and cannot be empty. Fill it in the config file and restart the application.");