namespace CTF.Application.Players.Combos;

public static class ComboServicesExtensions
{
    public static IServiceCollection AddComboServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ICombo, FlamethrowerVitality>()
            .AddSingleton<ICombo, GrenadesVitality>()
            .AddSingleton<ICombo, MolotovVitality>()
            .AddSingleton<ICombo, SatchelChargesVitality>()
            .AddSingleton<ICombo, TearGasVitality>();

        return services;
    }
}
