namespace CTF.Application.Teams.Flags.Events;

/// <summary>
/// This event occurs when a player has returned the flag to their team's base.
/// </summary>
public class OnFlagReturned(
    IPlayerRepository playerRepository,
    IWorldService worldService,
    TeamPickupService teamPickupService,
    TeamSoundsService teamSoundsService,
    PlayerStatsRenderer playerStatsRenderer) : IFlagEvent
{
    public FlagStatus FlagStatus => FlagStatus.Returned;

    public void Handle(Team team, Player player)
    {
        teamPickupService.CreateFlagFromBasePosition(team);
        teamPickupService.DestroyPickupWithInfo(team);
        teamSoundsService.PlayFlagReturnedSound(team);
        var message = Smart.Format(Messages.OnFlagReturned, new
        {
            PlayerName = player.Name,
            TeamName = team.Name,
            team.ColorName
        });
        worldService.SendClientMessage(team.ColorHex, message);
        worldService.GameText($"~n~~n~~n~{team.GameText}{team.ColorName} flag returned!", 5000, 3);

        PlayerInfo playerInfo = player.GetInfo();
        playerInfo.StatsPerRound.AddPoints(5);
        playerInfo.AddReturnedFlags();
        playerRepository.UpdateReturnedFlags(playerInfo);
        playerStatsRenderer.UpdateTextDraw(player);
    }
}
