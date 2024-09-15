namespace CTF.Application.Maps.Systems;

public class MapRotationSystem(
    MapRotationService mapRotationService,
    MapTextDrawRenderer mapTextDrawRenderer) : ISystem
{
    [Event]
    public void OnPlayerSpawn(Player player)
    {
        mapTextDrawRenderer.Show(player);
    }

    [Event]
    public void OnGameModeInit()
    {
        mapRotationService.StartRotation();
    }
}
