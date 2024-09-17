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

    [PlayerCommand("settimeleft")]
    public void SetTimeLeft(Player player, int minutes)
    {
        if (player.HasLowerRoleThan(RoleId.Moderator)) 
            return;

        var interval = new Minutes(minutes);
        TimeLeft timeLeft = mapRotationService.TimeLeft;
        Result result = timeLeft.SetInterval(interval);
        if(result.IsFailed)
        {
            player.SendClientMessage(Color.Red, result.Message);
            return;
        }

        mapTextDrawRenderer.UpdateTimeLeft(timeLeft);
    }
}
