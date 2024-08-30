namespace CTF.Host;

public class Startup : IStartup
{
    public void Configure(IServiceCollection services)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddEnvFile(".env", optional: false)
            .AddEnvironmentVariables()
            .Build();

        services.ChooseDatabaseProvider(configuration);
        services.AddApplicationServices();
        services.AddSingleton<IPasswordHasher, PasswordHasherBcrypt>();

        // Add systems to the services collection
        services
            .AddSystemsInAssembly(typeof(ApplicationServicesExtensions).Assembly)
            .AddSystemsInAssembly(typeof(Startup).Assembly);
    }

    public void Configure(IEcsBuilder builder)
    {
        // TODO: Enable desired ECS system features
        builder.EnableSampEvents()
            .EnablePlayerCommands()
            .EnableRconCommands();
    }
}
