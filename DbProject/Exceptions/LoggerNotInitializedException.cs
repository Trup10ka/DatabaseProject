namespace DbProject.Exceptions;

/// <summary>
/// Can occur when the logger is not initialized before the start and the first logger message due to any internal errors.
/// </summary>
public class LoggerNotInitializedException()
    : ApplicationException("Logger was not initialized. Make sure to call InitializeLogger() before using the logger.");
