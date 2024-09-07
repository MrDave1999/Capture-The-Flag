namespace CTF.Application.Players;

public class PlayerSystem(
    IWorldService worldService,
    IPlayerRepository playerRepository,
    RankUpgrade rankUpgrade,
    KillingSpreeUpgrade killingSpreeUpgrade) : ISystem
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
    public bool OnPlayerRequestSpawn(Player player)
    {
        var accountComponent = player.GetComponent<AccountComponent>();
        bool isNotLoggedInOrRegistered = accountComponent is null;
        if (isNotLoggedInOrRegistered)
        {
            player.SendClientMessage(Color.Red, Messages.LoginOrRegisterToContinue);
            return false;
        }

        return true;
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
        killingSpreeUpgrade.Increase(killer, killerInfo);
        rankUpgrade.RankUp(killer, killerInfo);
    }
}
