namespace CTF.Host;

public class GameModeInit(
    IWorldService worldService,
    IServerService serverService,
    MapInfoService mapInfoService,
    MapTextDrawRenderer mapTextDrawRenderer,
    TeamPickupService teamPickupService,
    TeamIconService teamIconService,
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
        serverService.AddPlayerClass((int)Team.Alpha.SkinId, new Vector3(0, 0, 0), 0);
        serverService.AddPlayerClass((int)Team.Beta.SkinId, new Vector3(0, 0, 0), 0);

        Result<IMap> mapResult = MapCollection.GetByName(serverSettings.MapName);
        if (mapResult.IsSuccess)
        {
            mapInfoService.Load(mapResult.Value);
        }
        CurrentMap currentMap = mapInfoService.Read();
        serverService.SendRconCommand($"mapname {currentMap.Name}");
        serverService.SendRconCommand($"loadfs {currentMap.Name}");
        mapTextDrawRenderer.UpdateMapName();

        worldService.SetWeather(currentMap.Weather);
        serverService.SetWorldTime(currentMap.WorldTime);
        teamPickupService.CreateFlagFromBasePosition(Team.Alpha);
        teamPickupService.CreateFlagFromBasePosition(Team.Beta);
        teamIconService.CreateFromBasePosition(Team.Alpha);
        teamIconService.CreateFromBasePosition(Team.Beta);
    }
}