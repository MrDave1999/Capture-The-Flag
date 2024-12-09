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
        serverService.SendRconCommand($"name {serverSettings.HostName}");
        serverService.SendRconCommand($"language {serverSettings.LanguageText}");
        serverService.SendRconCommand($"website {serverSettings.WebUrl}");
        serverService.SetGameModeText(serverSettings.GameModeText);
        serverService.UsePlayerPedAnims();
        serverService.DisableInteriorEnterExits();
    }
}
