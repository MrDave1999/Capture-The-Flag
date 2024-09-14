namespace CTF.Application.Maps.Systems;

public class MapSystem(MapTextDrawRenderer mapTextDraw) : ISystem
{
    [Event]
    public void OnPlayerSpawn(Player player)
    {
        mapTextDraw.Show(player);
    }
}
