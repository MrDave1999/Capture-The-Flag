﻿namespace CTF.Host;

public class Program
{
    static void Main(string[] args)
    {
        var envVars = new EnvLoader()
            .EnableFileNotFoundException()
            .AddEnvFile(".env")
            .Load();

        var encoding = $"{envVars["CodePageEncoding"]}.txt";
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "codepages");
        var path = Path.Combine(basePath, encoding);
        new GameModeBuilder()
            .UseEcs<Startup>()
            .UseEncoding(path)
            .Run();
    }
}
