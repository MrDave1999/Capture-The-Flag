﻿namespace CTF.Host;

public class Startup : IStartup
{
    public void Configure(IServiceCollection services)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddEnvFile(".env", optional: false)
            .AddEnvironmentVariables()
            .Build();

        var serverSettings = configuration
            .GetRequiredSection("ServerInfo")
            .Get<ServerSettings>();

        var commandCooldowns = configuration
            .GetRequiredSection("CommandCooldowns")
            .Get<CommandCooldowns>();

        services.ChooseDatabaseProvider(configuration);
        services.AddApplicationServices();
        services
            .AddSingleton<IPasswordHasher, PasswordHasherBcrypt>()
            .AddSingleton<IStreamerService, StreamerService>()
            .AddSingleton(serverSettings)
            .AddSingleton(commandCooldowns)
            .AddSingleton(new TopPlayersSettings());

        // Add systems to the services collection
        services
            .AddSystemsInAssembly(typeof(ApplicationServicesExtensions).Assembly)
            .AddSystemsInAssembly(typeof(Startup).Assembly);
    }

    public void Configure(IEcsBuilder builder)
    {
        // TODO: Enable desired ECS system features
        builder
            .RegisterMiddlewares()
            .EnableSampEvents()
            .EnablePlayerCommands()
            .EnableRconCommands()
            .EnableStreamerEvents();
    }
}
