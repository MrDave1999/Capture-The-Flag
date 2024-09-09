namespace CTF.Host;

public class GameModeInit(
    IWorldService worldService,
    IServerService serverService,
    MapInfoService mapInfoService,
    TeamPickupService teamPickupService,
    TeamIconService teamIconService) : ISystem
{
    private readonly CurrentMap _currentMap = mapInfoService.Read();

    [Event]
    public void OnGameModeInit()
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" GameMode Capture The Flag");
        Console.WriteLine("     Team DeathMatch");
        Console.WriteLine("----------------------------------\n");

        serverService.SendRconCommand("loadfs EntryMap");
        serverService.SendRconCommand("loadfs RemoveBuilding");
        serverService.UsePlayerPedAnims();
        serverService.DisableInteriorEnterExits();
        serverService.AddPlayerClass((int)Team.Alpha.SkinId, new Vector3(0, 0, 0), 0);
        serverService.AddPlayerClass((int)Team.Beta.SkinId, new Vector3(0, 0, 0), 0);
        serverService.SetGameModeText("Blank game mode");
        serverService.SendRconCommand($"mapname {_currentMap.Name}");
        serverService.SendRconCommand($"loadfs {_currentMap.Name}");
        worldService.SetWeather(_currentMap.Weather);
        serverService.SetWorldTime(_currentMap.WorldTime);
        teamPickupService.CreateFlagFromBasePosition(Team.Alpha);
        teamPickupService.CreateFlagFromBasePosition(Team.Beta);
        teamIconService.CreateFromBasePosition(Team.Alpha);
        teamIconService.CreateFromBasePosition(Team.Beta);
    }
}