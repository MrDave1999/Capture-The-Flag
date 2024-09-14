namespace CTF.Host;

public class GameModeInit(
    IServerService serverService,
    ServerSettings serverSettings) : ISystem
{
    [Event]
    public void OnGameModeInit()
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" GameMode Capture The Flag");
        Console.WriteLine("     Team DeathMatch");
        Console.WriteLine("----------------------------------\n");

        serverService.SendRconCommand("loadfs EntryMap");
        serverService.SendRconCommand("loadfs RemoveBuilding");
        serverService.SendRconCommand($"hostname {serverSettings.HostName}");
        serverService.SendRconCommand($"language {serverSettings.LanguageText}");
        serverService.SendRconCommand($"weburl {serverSettings.WebUrl}");
        serverService.SetGameModeText(serverSettings.GameModeText);
        serverService.UsePlayerPedAnims();
        serverService.DisableInteriorEnterExits();
    }
}
