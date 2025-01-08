namespace CTF.Host;

public class Startup : IStartup
{
    public void Configure(IServiceCollection services)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        services.ChooseDatabaseProvider(configuration);
        services
            .AddSerilog()
            .AddApplicationServices()
            .AddSettings(configuration)
            .AddSingleton<IPasswordHasher, PasswordHasherBcrypt>()
            .AddSingleton<IStreamerService, StreamerService>()
            .AddSingleton(configuration);

        // Add systems to the services collection
        services
            .AddSystemsInAssembly(typeof(ApplicationServicesExtensions).Assembly)
            .AddSystemsInAssembly(typeof(Startup).Assembly);
    }

    public void Configure(IEcsBuilder builder)
    {
        // TODO: Enable desired ECS system features
        builder
            .EnableExceptionHandler()
            .RegisterMiddlewares()
            .EnableSampEvents()
            .EnablePlayerCommands()
            .EnableRconCommands()
            .EnableStreamerEvents()
            .EnablePauseEvents()
            .EnableMapEvents();
    }
}
