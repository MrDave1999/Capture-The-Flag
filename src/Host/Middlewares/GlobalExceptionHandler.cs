namespace CTF.Host.Middlewares;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    EventDelegate next)
{
    public object Invoke(EventContext context)
    {
        try
        {
            return next(context);
        }
        catch (Exception exception) 
        {
            logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
            return null;
        }
    }
}
