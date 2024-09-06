namespace CTF.Application.Players.Combos;

public static class ComboServicesExtensions
{
    public static IServiceCollection AddComboServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IBenefit, HealthArmour>()
            .AddSingleton<IBenefit, GrenadesArmour>()
            .AddSingleton<IBenefit, MolotovArmour>()
            .AddSingleton<IBenefit, SatchelChargesArmour>()
            .AddSingleton<IBenefit, TearGasHealth>();

        return services;
    }
}
