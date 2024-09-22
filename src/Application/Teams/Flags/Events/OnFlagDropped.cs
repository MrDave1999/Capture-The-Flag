﻿namespace CTF.Application.Teams.Flags.Events;

/// <summary>
/// This event occurs when a player has dropped the opposing team's flag.
/// </summary>
public class OnFlagDropped(
    IPlayerRepository playerRepository,
    IWorldService worldService,
    TeamPickupService teamPickupService,
    TeamSoundsService teamSoundsService) : IFlagEvent
{
    public FlagStatus FlagStatus => FlagStatus.Dropped;

    public void Handle(Team team, Player player)
    {
        teamPickupService.CreateFlagFromVector3(team, player.Position);
        teamSoundsService.PlayFlagDroppedSound(team);
        team.Flag.RemoveCarrier();
        var message = Smart.Format(Messages.OnFlagDropped, new
        {
            PlayerName = player.Name,
            TeamName = team.Name,
            team.ColorName
        });
        worldService.SendClientMessage(team.ColorHex, message);
        worldService.GameText($"~n~~n~~n~{team.GameText}{team.ColorName} flag dropped!", 5000, 3);

        PlayerInfo playerInfo = player.GetInfo();
        playerInfo.AddDroppedFlags();
        playerRepository.UpdateDroppedFlags(playerInfo);
    }
}
