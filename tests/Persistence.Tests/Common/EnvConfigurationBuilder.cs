namespace Persistence.Tests.Common;

public static class EnvConfigurationBuilder
{
    public static IConfiguration Instance { get; }
    static EnvConfigurationBuilder()
    {
        Instance = new ConfigurationBuilder()
            .AddEnvFile(".env.test", optional: false)
            .Build();
    }
}
