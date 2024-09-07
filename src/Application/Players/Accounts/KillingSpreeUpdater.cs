namespace CTF.Application.Players.Accounts;

public class KillingSpreeUpdater(
    IWorldService worldService,
    IPlayerRepository playerRepository)
{
    public void Update(Player player, PlayerInfo playerInfo)
    {
        playerInfo.StatsPerRound.AddKillingSpree();
        int currentKillingSpree = playerInfo.StatsPerRound.KillingSpree;
        if (currentKillingSpree >= 2)
        {
            player.GameText($"KILL X{currentKillingSpree}", 3000, 3);
            const int earnedPoints = 20;
            playerInfo.StatsPerRound.AddPoints(earnedPoints);
            player.AddHealth(10);

            if (currentKillingSpree > playerInfo.MaxKillingSpree)
            {
                playerInfo.SetMaxKillingSpree(currentKillingSpree);
                playerRepository.UpdateMaxKillingSpree(playerInfo);
            }

            if (currentKillingSpree % 3 == 0)
            {
                var message = Smart.Format(Messages.ConsecutiveKills, new 
                {
                    PlayerName = player.Name,
                    Kills = currentKillingSpree
                });
                // Sample Message:
                // Dave has had 3 consecutive kills without dying.
                worldService.SendClientMessage(Color.Orange, message);
                player.AddHealth(40);
            }
        }
    }
}
