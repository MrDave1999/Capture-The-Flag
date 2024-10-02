﻿namespace CTF.Application.Teams.Flags;

public class FlagSystem(
    IDictionary<FlagStatus, IFlagEvent> flagEvents,
    PlayerStatsRenderer playerStatsRenderer,
    OnFlagDropped onFlagDropped) : ISystem
{
    [Event]
    public void OnPlayerDisconnect(Player player, DisconnectReason reason)
    {
        PlayerInfo playerInfo = player.GetInfo();
        if (playerInfo.HasCapturedFlag())
        {
            Team currentTeam = playerInfo.Team;
            onFlagDropped.Handle(currentTeam.RivalTeam, player);
        }
    }

    [Event]
    public void OnPlayerDeath(Player deadPlayer, Player killer, Weapon reason)
    {
        PlayerInfo deadPlayerInfo = deadPlayer.GetInfo();
        if (deadPlayerInfo.HasCapturedFlag())
        {
            Team currentTeam = deadPlayerInfo.Team;
            onFlagDropped.Handle(currentTeam.RivalTeam, deadPlayer);
            if (killer.IsValidPlayer())
            {
                PlayerInfo killerInfo = killer.GetInfo();
                killerInfo.StatsPerRound.AddPoints(4);
                killer.AddHealth(10);
                killer.AddScore(2);
                playerStatsRenderer.UpdateTextDraw(killer);
            }
        }
    }

    [Event]
    public void OnPlayerPickUpPickup(Player player, Pickup pickup)
    {
        if (pickup.Model == (int)FlagModel.Red)
        {
            FlagStatus flagStatus = Team.Alpha.GetFlagStatus(flagPicker: player);
            IFlagEvent flagEvent = flagEvents[flagStatus];
            flagEvent.Handle(Team.Alpha, player);
        }
        else if (pickup.Model == (int)FlagModel.Blue)
        {
            FlagStatus flagStatus = Team.Beta.GetFlagStatus(flagPicker: player);
            IFlagEvent flagEvent = flagEvents[flagStatus];
            flagEvent.Handle(Team.Beta, player);
        }
        else if (pickup.Model == (int)ExteriorMarker.Red)
        {
            if (player.Team == (int)TeamId.Alpha)
                player.GameText(Messages.RedFlagIsNotAtBasePosition, 5000, 3);
        }
        else if (pickup.Model == (int)ExteriorMarker.Blue)
        {
            if (player.Team == (int)TeamId.Beta)
                player.GameText(Messages.BlueFlagIsNotAtBasePosition, 5000, 3);
        }
    }
}
