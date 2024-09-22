﻿namespace CTF.Application.Teams.Flags.Events;

/// <summary>
/// This event occurs when a player has taken the flag from a position other than the base.
/// </summary>
public class OnFlagTaken(
    IWorldService worldService,
    TeamPickupService teamPickupService,
    TeamSoundsService teamSoundsService,
    FlagAutoReturnTimer flagAutoReturnTimer) : IFlagEvent
{
    public FlagStatus FlagStatus => FlagStatus.Taken;

    public void Handle(Team team, Player player)
    {
        teamPickupService.DestroyFlag(team);
        teamSoundsService.PlayFlagTakenSound(team);
        flagAutoReturnTimer.Stop(team);
        var message = Smart.Format(Messages.OnFlagTaken, new
        {
            PlayerName = player.Name,
            TeamName = team.Name,
            team.ColorName
        });
        worldService.SendClientMessage(team.ColorHex, message);
        worldService.GameText($"~n~~n~~n~{team.GameText}{team.ColorName} flag taken!", 5000, 3);
    }
}
