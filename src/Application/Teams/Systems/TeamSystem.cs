namespace CTF.Application.Teams.Systems;

public class TeamSystem(TeamTextDrawRenderer teamTextDraw) : ISystem
{
    [Event]
    public void OnPlayerSpawn(Player player)
    {
        teamTextDraw.Show(player);
    }
}
