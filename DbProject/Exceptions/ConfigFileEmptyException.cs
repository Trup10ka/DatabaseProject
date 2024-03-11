namespace DbProject.Exceptions;

/// <summary>
/// ConfigFileException occurs when the config file is empty. Program fills in the template config file with default values.
/// </summary>
public class ConfigFileEmptyException() 
    : ApplicationException("Config file is empty. Template config was filled in with default values. Please fill it out and restart the application.");