namespace CTF.Host.Extensions;

public static class AppSettingsExtensions
{
    public static IServiceCollection AddSettings(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var serverSettings = configuration
            .GetRequiredSection("ServerInfo")
            .Get<ServerSettings>();

        var commandCooldowns = configuration
            .GetRequiredSection("CommandCooldowns")
            .Get<CommandCooldowns>();

        var topPlayersSettings = configuration
            .GetRequiredSection("TopPlayers")
            .Get<TopPlayersSettings>();

        services
            .AddSingleton(serverSettings)
            .AddSingleton(commandCooldowns)
            .AddSingleton(topPlayersSettings);

        return services;
    }
}
