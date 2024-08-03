namespace CTF.Host;

public class Startup : IStartup
{
    public void Configure(IServiceCollection services)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddEnvFile(".env", optional: false)
            .AddEnvironmentVariables()
            .Build();

        // TODO: Add services and systems to the services collection
        services.AddSystem<System1>();
    }

    public void Configure(IEcsBuilder builder)
    {
        // TODO: Enable desired ECS system features
        builder.EnableSampEvents()
            .EnablePlayerCommands()
            .EnableRconCommands();
    }
}