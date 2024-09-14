namespace CTF.Application.Maps.Systems;

public class MapSystem(MapTextDrawRenderer mapTextDrawRenderer) : ISystem
{
    [Event]
    public void OnPlayerSpawn(Player player)
    {
        mapTextDrawRenderer.Show(player);
    }
}
