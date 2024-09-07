namespace CTF.Application.Players.Accounts;

public class KillingSpreeUpgrade(
    IWorldService worldService,
    IPlayerRepository playerRepository)
{
    public void Increase(Player player, PlayerInfo playerInfo)
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

            if (playerInfo.StatsPerRound.HasConsecutiveKills())
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
