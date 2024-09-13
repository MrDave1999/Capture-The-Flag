namespace CTF.Application.Players;

public class PlayerSpawnSystem(MapInfoService mapInfoService) : ISystem
{
    private readonly CurrentMap _currentMap = mapInfoService.Read();

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
