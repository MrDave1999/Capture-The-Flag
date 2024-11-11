namespace CTF.Host.Extensions;

public static class SerilogExtensions
{
    public static IServiceCollection AddSerilog(this IServiceCollection services)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "logs/ctf-.txt");
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "{Exception}", theme: ConsoleTheme.None)
            .WriteTo.File(path, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog(dispose: true);
        });

        return services;
    }
}
