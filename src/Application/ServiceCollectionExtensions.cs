namespace CTF.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ServerTimeService>()
            .AddSingleton<MapInfoService>()
            .AddSingleton<RankUpgrade>()
            .AddSingleton<KillingSpreeUpgrade>()
            .AddComboServices();

        return services;
    }
}
