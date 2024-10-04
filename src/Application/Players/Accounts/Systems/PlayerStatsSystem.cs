namespace CTF.Application.Players.Accounts.Systems;

public class PlayerStatsSystem(
    IDialogService dialogService,
    IPlayerRepository playerRepository,
    PlayerRankUpdater playerRankUpdater,
    KillingSpreeUpdater killingSpreeUpdater,
    PlayerStatsRenderer playerStatsRenderer) : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        playerStatsRenderer.CreateTextDraw(player);
    }

    [Event]
    public void OnPlayerSpawn(Player player)
    {
        playerStatsRenderer.UpdateTextDraw(player);
    }

    [Event]
    public void OnPlayerDisconnect(Player player, DisconnectReason reason)
    {
        if (player.IsUnauthenticated())
            return;

        PlayerInfo playerInfo = player.GetInfo();
        playerInfo.SetLastConnection();
        playerRepository.UpdateLastConnection(playerInfo);
    }

    [Event]
    public void OnPlayerDeath(Player deadPlayer, Player killer, Weapon reason)
    {
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
        killer.AddScore();
        playerRepository.UpdateTotalKills(killerInfo);
        killingSpreeUpdater.Update(killer, killerInfo);
        playerRankUpdater.Update(killer, killerInfo);
        playerStatsRenderer.UpdateTextDraw(killer);
    }

    [PlayerCommand("mystats")]
    public void ShowStats(Player player)
    {
        var content = GetPlayerContent(player);
        var dialog = new MessageDialog($"Stats: {player.Name}", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }

    [PlayerCommand("stats")]
    public void ShowStats(Player currentPlayer, Player targetPlayer)
    {
        var content = GetPlayerContent(targetPlayer);
        var dialog = new MessageDialog($"Stats: {targetPlayer.Name}", content, "Close");
        dialogService.ShowAsync(currentPlayer, dialog);
    }

    private static string GetPlayerContent(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        string createdAt = player.IsUnauthenticated() ? 
            "None" : 
            playerInfo.CreatedAt.GetDateWithStandardFormat();

        var content =
        $"""
        Current Team: {playerInfo.Team.Name}
        Score for Round: {player.Score}
        Kills for Round: {playerInfo.StatsPerRound.Kills}
        Deaths for Round: {playerInfo.StatsPerRound.Deaths}
        Killing Spree for Round: {playerInfo.StatsPerRound.KillingSpree}
        Points: {playerInfo.StatsPerRound.Points}/100
        Max Killing Spree: {playerInfo.MaxKillingSpree}
        Total Kills: {playerInfo.TotalKills}
        Total Deaths: {playerInfo.TotalDeaths}
        Brought Flags: {playerInfo.BroughtFlags}
        Captured Flags: {playerInfo.CapturedFlags}
        Dropped Flags: {playerInfo.DroppedFlags}
        Returned Flags: {playerInfo.ReturnedFlags}
        HeadShots: {playerInfo.HeadShots}
        Role: {playerInfo.RoleId}
        Rank: {playerInfo.RankId}
        Registration Date: {createdAt}
        """;
        return content;
    }
}
