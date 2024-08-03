namespace CTF.Host;

public class System1 : ISystem
{
    [Event]
    public void OnGameModeInit(IServerService serverService)
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" Blank game mode by your name here");
        Console.WriteLine("----------------------------------\n");

        serverService.AddPlayerClass(8, new Vector3(0, 0, 7), 0);
        serverService.SetGameModeText("Blank game mode");

        // TODO: Put logic to initialize your game mode here
    }

    [PlayerCommand("hello")]
    public void HelloCommand(Player player)
    {
        player.SendClientMessage($"Hello, {player.Name}!");
    }
}