using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Vip
{
    public partial class CmdVip
    {
        [Command("invisible", Shortcut = "invisible")]
        private static void InvisibleCommand(Player player)
        {
            if (player.IsVipLevel(3)) return;
            if(player.IsCapturedFlag())
            {
                player.SendClientMessage(Color.Red, "Error: No puedes usar el comando mientras tengas la bandera.");
                return;
            }
            if(player.IsInvisible)
            {
                player.SendClientMessage(Color.Red, "Error: Usted ya se encuentra invisible.");
                return;
            }
            player.EnableInvisibility();
            player.IsInvisible = true;
            player.SendClientMessage(Color.Yellow, "* Estás invisible, ningún jugador podrá verte.");
            player.SendClientMessage(Color.Yellow, "* Usa /visible para que la gente pueda verte.");
        }

        [Command("visible", Shortcut = "visible")]
        private static void VisibleCommand(Player player)
        {
            if (player.IsVipLevel(3)) return;
            if (!player.IsInvisible)
            {
                player.SendClientMessage(Color.Red, "Error: Usted ya se encuentra visible.");
                return;
            }
            player.DisableInvisibility();
            player.IsInvisible = false;
            player.SendClientMessage(Color.Yellow, "* Estás visible, ahora los jugadores podrán verte.");
        }

        [Command("flame", Shortcut = "flame")]
        private static void FlameCommand(Player player)
        {
            if (player.IsVipLevel(3)) return;
            player.GiveWeapon(Weapon.FlameThrower);
        }

        [Command("clearchat", Shortcut = "clearchat")]
        private static void ClearChat(Player player)
        {
            if (player.IsVipLevel(3)) return;
            for (int i = 0; i != 100; ++i)
                player.SendClientMessage(" ");
        }
    }
}
