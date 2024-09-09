namespace CTF.Host;

public class GameMode(IServerService serverService) : ISystem
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
        serverService.UsePlayerPedAnims();
        serverService.DisableInteriorEnterExits();
        serverService.AddPlayerClass((int)Team.Alpha.SkinId, new Vector3(0, 0, 0), 0);
        serverService.AddPlayerClass((int)Team.Beta.SkinId, new Vector3(0, 0, 0), 0);
        serverService.SetGameModeText("Blank game mode");
    }
}