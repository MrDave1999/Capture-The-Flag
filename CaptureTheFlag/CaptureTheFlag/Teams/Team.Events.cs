using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Teams
{
    public partial class Team
    {
        private void OnPickUp(object sender, PickUpPickupEventArgs e)
        {
            var player = e.Player as Player;
            if (player.Team == (int)Id)
                player.GameText($"~n~~n~~n~{ColorGameText}recupera la bandera {NameColor}!", 5000, 3);
            else if (Flag.PlayerCaptured == null)
                player.GameText($"~n~~n~~n~{ColorGameText}la bandera {NameColor} esta caida!", 5000, 3);
            else if (player.IsCapturedFlag())
                player.GameText($"~n~~n~~n~{ColorGameText}lleva la bandera {NameColor} a tu base!", 5000, 3);
            else
                player.GameText($"~n~~n~~n~{ColorGameText}la bandera {NameColor} ya fue capturada!", 5000, 3);
        }
    }
}
