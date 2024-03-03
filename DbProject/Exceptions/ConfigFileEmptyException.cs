namespace DbProject.Exceptions;

public class ConfigFileEmptyException() 
    : ApplicationException("Config file is empty. Template config was filled in with default values. Please fill it out and restart the application.");