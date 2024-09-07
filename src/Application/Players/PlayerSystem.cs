namespace CTF.Application.Players;

public class PlayerSystem(
    IPlayerRepository playerRepository,
    RankUpgrade rankUpgrade) : ISystem
{
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
    public void OnPlayerDeath(Player player, Player killer, Weapon reason)
    {
        if (killer.IsInvalidPlayer())
            return;

        PlayerInfo killerInfo = killer.GetInfo();
        killerInfo.StatsPerRound.AddKills();
        killerInfo.AddTotalKills();
        playerRepository.UpdateTotalKills(killerInfo);
        rankUpgrade.RankUp(killer, killerInfo);
    }
}
