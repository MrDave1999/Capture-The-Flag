namespace CTF.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ServerTimeService>()
            .AddSingleton<MapInfoService>()
            .AddSingleton<PlayerRankUpdater>()
            .AddSingleton<KillingSpreeUpdater>()
            .AddSingleton<ClassSelectionTextDraw>()
            .AddComboServices()
            .AddTeamServices();

        return services;
    }
}
