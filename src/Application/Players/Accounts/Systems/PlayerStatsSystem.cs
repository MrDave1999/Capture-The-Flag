﻿namespace CTF.Application.Players.Accounts.Systems;

public class PlayerStatsSystem(IDialogService dialogService) : ISystem
{
    [PlayerCommand("stats")]
    public void ShowStats(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        var content =
        $"""
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
        Registration Date: {playerInfo.CreatedAt.GetDateWithStandardFormat()}
        """;
        var dialog = new MessageDialog($"Stats: {playerInfo.Name}", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }
}
