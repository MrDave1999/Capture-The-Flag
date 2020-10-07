using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
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
            player.Health = 0;
        }

        [Command("team", Shortcut = "team")]
        private static void Team(Player player)
        {
            player.SendClientMessage($"Alpha: {GameMode.TeamAlpha.Members}, Beta: {GameMode.TeamBeta.Members}");
            player.SendClientMessage($"{player.IsCapturedFlag()}");
        }

        [Command("tc", Shortcut = "tc", UsageMessage = "/tc [mensaje]")]
        public static void TeamChat(Player player, string msg)
        {
            if(player.PlayerTeam.Id == TeamID.None)
            {
                player.SendClientMessage(Color.Red, "Error: Debes estar en un equipo para usar el TeamChat.");
                return;
            }
            foreach(Player player1 in BasePlayer.GetAll<Player>())
                if(!player1.IsSelectionClass && player.PlayerTeam.Id == player1.PlayerTeam.Id)
                    player1.SendClientMessage($"{player.PlayerTeam.OtherColor}[Team Chat] {player.Name} [{player.Id}]: {msg}");
        }
    }
}
