namespace DbProject.Exceptions;

/// <summary>
/// ConfigFileNotFoundException occurs when the config file is not found. Program creates a template config file.
/// </summary>
public class ConfigFileNotFoundException() 
    : ApplicationException("Config file not found. Template config file was created. Please fill it out and restart the application.");