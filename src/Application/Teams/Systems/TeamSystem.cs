namespace CTF.Application.Teams.Systems;

public class TeamSystem(TeamTextDrawRenderer teamTextDrawRenderer) : ISystem
{
    [Event]
    public void OnPlayerSpawn(Player player)
    {
        teamTextDrawRenderer.Show(player);
    }
}
