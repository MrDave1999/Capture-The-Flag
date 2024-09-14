﻿namespace CTF.Application.Teams;

public static class TeamServicesExtensions
{
    public static IServiceCollection AddTeamServices(this IServiceCollection services)
    {
        services
            .AddSingleton<TeamPickupService>()
            .AddSingleton<TeamIconService>()
            .AddSingleton<TeamTextDrawRenderer>()
            .AddSingleton<ClassSelectionTextDrawRenderer>();

        return services;
    }
}
