namespace CTF.Application.Players;

public class PlayerSpawnSystem(MapInfoService mapInfoService) : ISystem
{
    private readonly CurrentMap _currentMap = mapInfoService.Read();

    [Event]
    public bool OnPlayerRequestSpawn(Player player)
    {
        if (player.IsNotLoggedInOrRegistered())
        {
            player.SendClientMessage(Color.Red, Messages.LoginOrRegisterToContinue);
            return false;
        }
        Team selectedTeam = player.Team == (int)TeamId.Alpha ? Team.Alpha : Team.Beta;
        if (selectedTeam.IsFull())
        {
            string gameText = selectedTeam.GetAvailabilityMessage();
            player.GameText(gameText, 999999999, 3);
            return false;
        }
        player.DisableClassSelection();
        player.GameText("_", 1000, 4);
        player.GetInfo().SetTeam(selectedTeam.Id);
        selectedTeam.Members.Add(player);
        return true;
    }

    [Event]
    public void OnPlayerDisconnect(Player player, DisconnectReason reason)
    {
        if (player.IsNotLoggedInOrRegistered())
            return;

        PlayerInfo playerInfo = player.GetInfo();
        if (playerInfo.Team == Team.None)
            return;

        playerInfo.Team.Members.Remove(player);
    }

    [Event]
    public void OnPlayerSpawn(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        SpawnLocation spawnLocation = _currentMap.GetRandomSpawnLocation(playerInfo.Team.Id);
        player.Position = spawnLocation.Position;
        player.Angle = spawnLocation.Angle;
        player.Interior = _currentMap.Interior;
        player.Color = playerInfo.Team.ColorHex;
        player.Team = (int)playerInfo.Team.Id;
        if (playerInfo.HasSkin())
        {
            player.Skin = playerInfo.SkinId;
        }
    }
}
