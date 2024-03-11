namespace DbProject.Exceptions;


/// <summary>
/// Can occur at the start of the CLI client, when the DbClient is not initialized due to any internal errors.
/// </summary>
public class DbClientNotInitialized() 
    : ApplicationException("Exception occured when starting the CLI client, DbClient is not initialized.");