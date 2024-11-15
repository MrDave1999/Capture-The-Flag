﻿namespace CTF.Application.Teams.Flags;

/// <summary>
/// A system that handles the pause logic for flag carriers.
/// </summary>
/// <remarks>
/// It checks if the carrier is paused and updates the timer. If the timer runs out, the flag is returned to the base.
/// </remarks>
public class FlagCarrierPauseHandler(
    IWorldService worldService,
    ITimerService timerService,
    TeamPickupService teamPickupService,
    TeamSoundsService teamSoundsService,
    ServerSettings serverSettings) : ISystem
{
    [Event]
    public void OnPlayerDisconnect(Player player, DisconnectReason reason)
    {
        var pauseTimerReference = player.GetComponent<PauseTimerReference>();
        if (pauseTimerReference is null)
            return;

        timerService.Stop(pauseTimerReference.Value);
    }

    [Event]
    public void OnPlayerPauseStateChange(Player player, bool pauseState)
    {
        PlayerInfo playerInfo = player.GetInfo();
        if (pauseState && playerInfo.HasCapturedFlag())
        {
            var interval = TimeSpan.FromSeconds(serverSettings.FlagCarrierPauseTime);
            var timerReference = timerService.Start(OnComplete, interval);
            player.AddComponent<PauseTimerReference>(timerReference);
        }
        else if (!pauseState && playerInfo.HasCapturedFlag())
        {
            var pauseTimerReference = player.GetComponent<PauseTimerReference>();
            timerService.Stop(pauseTimerReference.Value);
            pauseTimerReference.Destroy();
        }

        void OnComplete(IServiceProvider serviceProvider)
        {
            if (!player.IsComponentAlive)
                return;

            var pauseTimerReference = player.GetComponent<PauseTimerReference>();
            timerService.Stop(pauseTimerReference.Value);
            pauseTimerReference.Destroy();

            if (!playerInfo.HasCapturedFlag())
                return;

            Team rivalTeam = playerInfo.Team.RivalTeam;
            rivalTeam.IsFlagAtBasePosition = true;
            rivalTeam.Flag.RemoveCarrier();
            player.HideOnRadarMap();
            teamPickupService.CreateFlagFromBasePosition(rivalTeam);
            teamPickupService.DestroyExteriorMarker(rivalTeam);
            teamSoundsService.PlayFlagReturnedSound(rivalTeam);
            var message = Smart.Format(Messages.FlagAutoReturn2, new
            {
                rivalTeam.ColorName,
                PlayerName = player.Name,
                Seconds = serverSettings.FlagCarrierPauseTime
            });
            worldService.SendClientMessage(rivalTeam.ColorHex, message);
            worldService.GameText($"~n~~n~~n~{rivalTeam.GameText}{rivalTeam.ColorName} flag returned!", 5000, 3);
        }
    }

    private class PauseTimerReference(TimerReference value) : Component
    {
        public TimerReference Value { get; } = value;
    }
}
