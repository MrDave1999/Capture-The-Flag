﻿namespace CTF.Host.Extensions;

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

        var serverOwnerSettings = configuration
            .GetRequiredSection("ServerOwner")
            .Get<ServerOwnerSettings>();

        var flagCarrierSettings = configuration
            .GetRequiredSection("FlagCarrier")
            .Get<FlagCarrierSettings>();

        var antiCBugSettings = configuration
            .GetRequiredSection("AntiCBug")
            .Get<AntiCBugSettings>();

        services
            .AddSingleton(serverSettings)
            .AddSingleton(commandCooldowns)
            .AddSingleton(topPlayersSettings)
            .AddSingleton(serverOwnerSettings)
            .AddSingleton(flagCarrierSettings)
            .AddSingleton(antiCBugSettings);

        return services;
    }
}
