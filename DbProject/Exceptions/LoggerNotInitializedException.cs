namespace DbProject.Exceptions;

public class LoggerNotInitializedException()
    : ApplicationException("Logger was not initialized. Make sure to call InitializeLogger() before using the logger.");
