namespace CTF.Application.Players.Combos;

public static class ComboServicesExtensions
{
    public static IServiceCollection AddComboServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ICombo, HealthArmour>()
            .AddSingleton<ICombo, GrenadesArmour>()
            .AddSingleton<ICombo, MolotovArmour>()
            .AddSingleton<ICombo, SatchelChargesArmour>()
            .AddSingleton<ICombo, TearGasHealth>();

        return services;
    }
}
