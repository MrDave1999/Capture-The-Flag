namespace CTF.Host;

public class Program
{
    static void Main(string[] args)
    {
        new EnvLoader()
            .EnableFileNotFoundException()
            .AddEnvFile(".env")
            .Load();

        new GameModeBuilder()
            .UseEcs<Startup>()
            .Run();
    }
}
