﻿namespace CTF.Application.Players;

public class PlayerSystem(IPlayerRepository playerRepository) : ISystem
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

        PlayerInfo killerInfo = killer.GetComponent<AccountComponent>().PlayerInfo;
        killerInfo.StatsPerRound.AddKills();
        killerInfo.AddTotalKills();
        playerRepository.UpdateTotalKills(killerInfo);
        if (killerInfo.CanMoveUpToNextRank())
        {
            IRank nextRank = RankCollection.GetNextRank(killerInfo.RankId).Value;
            killer.SendClientMessage(Color.Yellow, Smart.Format(Messages.NextRank, nextRank));
            killer.SendClientMessage(Color.Orange, Messages.RankUpAward);
            killer.Armour = 100;
            killer.Health = 100;
            killerInfo.StatsPerRound.AddPoints(100);
            killerInfo.SetRank(nextRank.Id);
            playerRepository.UpdateRank(killerInfo);
        }
    }
}