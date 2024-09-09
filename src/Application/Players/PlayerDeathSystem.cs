namespace CTF.Application.Players;

public class PlayerDeathSystem(
    IWorldService worldService,
    IPlayerRepository playerRepository,
    PlayerRankUpdater playerRankUpdater,
    KillingSpreeUpdater killingSpreeUpdater) : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        worldService.SendDeathMessage(killer: null, player, Weapon.Connect);
    }

    [Event]
    public void OnPlayerDisconnect(Player player, DisconnectReason reason) 
    {
        worldService.SendDeathMessage(killer: null, player, Weapon.Disconnect);
    }

    [Event]
    public void OnPlayerDeath(Player deadPlayer, Player killer, Weapon reason)
    {
        worldService.SendDeathMessage(killer, deadPlayer, reason);
        PlayerInfo deadPlayerInfo = deadPlayer.GetInfo();
        deadPlayerInfo.StatsPerRound.AddDeaths();
        deadPlayerInfo.StatsPerRound.ResetKillingSpree();
        deadPlayerInfo.AddTotalDeaths();
        playerRepository.UpdateTotalDeaths(deadPlayerInfo);

        if (killer.IsInvalidPlayer())
            return;

        PlayerInfo killerInfo = killer.GetInfo();
        killerInfo.StatsPerRound.AddKills();
        killerInfo.AddTotalKills();
        playerRepository.UpdateTotalKills(killerInfo);
        killingSpreeUpdater.Update(killer, killerInfo);
        playerRankUpdater.Update(killer, killerInfo);
    }
}
