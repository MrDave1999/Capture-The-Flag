namespace CTF.Host;

public class Program
{
    static void Main(string[] args)
    {
        new GameModeBuilder()
            .UseEcs<Startup>()
            .Run();
    }
}
