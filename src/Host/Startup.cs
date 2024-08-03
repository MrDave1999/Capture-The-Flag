namespace CTF.Host;

public class Startup : IStartup
{
    public void Configure(IServiceCollection services)
    {
        // TODO: Add services and systems to the services collection
        services.AddSystem<System1>();
    }

    public void Configure(IEcsBuilder builder)
    {
        // TODO: Enable desired ECS system features
        builder.EnableSampEvents()
            .EnablePlayerCommands()
            .EnableRconCommands();
    }
}