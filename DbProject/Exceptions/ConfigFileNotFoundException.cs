namespace DbProject.Exceptions;

public class ConfigFileNotFoundException() 
    : ApplicationException("Config file not found. Template config file was created. Please fill it out and restart the application.");