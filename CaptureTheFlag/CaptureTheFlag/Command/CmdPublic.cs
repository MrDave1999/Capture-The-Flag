using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command
{
    [CommandGroup("public")]
    public class CmdPublic
    {
        private static bool IsCaptureFlag(Player player)
        {
            if(player.IsCapturedFlag())
            {
                player.SendClientMessage(Color.Red, "Error: Usted no puede usar este comando.");
                return true;
            }
            return false;
        }

        [Command("force", Shortcut = "force")]
        private static void Force(Player player)
        {
            if (IsCaptureFlag(player)) return;
            player.SetForceClass();
        }

        [Command("kill", Shortcut = "kill")]
        private static void Kill(Player player)
        {
            if (IsCaptureFlag(player)) return;
            player.Health = 0;
            ++player.Data.Deaths;
        }

        [Command("team", Shortcut = "team")]
        private static void Team(Player player)
        {
            player.SendClientMessage($"Alpha: {GameMode.TeamAlpha.Members}, Beta: {GameMode.TeamBeta.Members}");
            player.SendClientMessage($"{player.IsCapturedFlag()}");
        }
    }
}
