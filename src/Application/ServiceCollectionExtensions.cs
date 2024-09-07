namespace CTF.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ServerTimeService>()
            .AddSingleton<MapInfoService>()
            .AddSingleton<RankUpgrade>()
            .AddSingleton<KillingSpreeUpdater>()
            .AddComboServices();

        return services;
    }
}
