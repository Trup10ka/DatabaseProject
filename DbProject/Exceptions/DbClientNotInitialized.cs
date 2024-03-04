namespace DbProject.Exceptions;

public class DbClientNotInitialized() 
    : ApplicationException("Exception occured when starting the CLI client, DbClient is not initialized.");