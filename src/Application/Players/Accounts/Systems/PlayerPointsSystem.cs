namespace CTF.Application.Players.Accounts.Systems;

public class PlayerPointsSystem(
    IEntityManager entityManager,
    IWorldService worldService,
    PlayerStatsRenderer playerStatsRenderer,
    ServerTimeService serverTimeService) : ISystem
{
    [PlayerCommand("addpoints")]
    public void AddPointsToPlayer(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        int points)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        PlayerInfo targetPlayerInfo = targetPlayer.GetInfo();
        Result result = targetPlayerInfo.StatsPerRound.AddPoints(points);
        if (result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        {
            var message = Smart.Format(Messages.AddPointsToPlayer, new
            {
                Points = points,
                PlayerName = targetPlayer.Name
            });
            currentPlayer.SendClientMessage(Color.Yellow, message);
        }
        {
            var message = Smart.Format(Messages.ReceivePointsFromPlayer, new
            {
                Points = points,
                PlayerName = currentPlayer.Name
            });
            targetPlayer.SendClientMessage(Color.Yellow, message);
        }
        playerStatsRenderer.UpdateTextDraw(targetPlayer);
    }

    [PlayerCommand("addallpoints")]
    public void AddPointsToAllPlayers(Player currentPlayer, int points)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        IEnumerable<Player> players = entityManager.GetComponents<Player>();
        foreach (Player targetPlayer in players)
        {
            PlayerInfo targetPlayerInfo = targetPlayer.GetInfo();
            Result result = targetPlayerInfo.StatsPerRound.AddPoints(points);
            if (result.IsFailed)
            {
                currentPlayer.SendClientMessage(Color.Red, result.Message);
                return;
            }
            playerStatsRenderer.UpdateTextDraw(targetPlayer);
        }

        var message = Smart.Format(Messages.AddPointsToAllPlayers, new
        {
            PlayerName = currentPlayer.Name,
            Points = points
        });
        worldService.SendClientMessage(Color.Yellow, message);
    }

    [PlayerCommand("givemepoints")]
    public void GiveMePoints(Player currentPlayer) 
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.VIP))
            return;

        const int Minutes = 4;
        var waitTimeComponent = currentPlayer.GetComponent<WaitTimeComponent>();
        if (waitTimeComponent.Value > serverTimeService.GetTime())
        {
            var message = Smart.Format(Messages.TimeRequiredToReuseCommand, new { Minutes });
            currentPlayer.SendClientMessage(Color.Red, message);
            return;
        }

        waitTimeComponent.Value = serverTimeService.GetTime() + (Minutes * 60);
        PlayerInfo currentPlayerInfo = currentPlayer.GetInfo();
        currentPlayerInfo.StatsPerRound.AddPoints(100);
        playerStatsRenderer.UpdateTextDraw(currentPlayer);
        currentPlayer.SendClientMessage(Color.Yellow, Messages.GiveMePoints);
    }

    [Event]
    public void OnPlayerConnect(Player player)
        => player.AddComponent<WaitTimeComponent>();

    private class WaitTimeComponent : Component
    {
        public int Value { get; set; }
    }
}