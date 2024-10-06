namespace CTF.Application.Players.Accounts.Services;

public class PlayerRankUpdater(IPlayerRepository playerRepository)
{
    public void Update(Player player, PlayerInfo playerInfo)
    {
        if (playerInfo.CanMoveUpToNextRank())
        {
            IRank nextRank = RankCollection.GetNextRank(playerInfo.RankId).Value;
            player.SendClientMessage(Color.Yellow, Smart.Format(Messages.NextRank, nextRank));
            player.SendClientMessage(Color.Orange, Messages.RankUpAward);
            player.Armour = 100;
            player.Health = 100;
            playerInfo.StatsPerRound.AddCoins(100);
            playerInfo.SetRank(nextRank.Id);
            playerRepository.UpdateRank(playerInfo);
        }
    }
}
