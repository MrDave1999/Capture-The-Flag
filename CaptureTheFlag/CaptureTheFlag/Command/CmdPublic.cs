using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
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

        [Command("tstats", Shortcut = "tstats")]
        private static void StatsTeam(Player player)
        {
            var statsList = new MessageDialog("Stats Team", "","Aceptar");
            statsList.Message = GameMode.TeamAlpha.OtherColor +
                "Team: Alpha"  +
                "\nColor Team: Red" +
                "\nUsers: " + GameMode.TeamAlpha.Members +
                "\nScore: " + GameMode.TeamAlpha.Score +
                "\nTotal Kills: " + GameMode.TeamAlpha.Kills +
                "\nTotal Deaths: " + GameMode.TeamAlpha.Deaths +
                "\nCaptured Flag by: " + (GameMode.TeamAlpha.Flag.PlayerCaptured == null ? "None" : $"{GameMode.TeamAlpha.Flag.PlayerCaptured.Name}") +
                GameMode.TeamBeta.OtherColor +
                "\n\nTeam: Beta" +
                "\nColor Team: Blue" +
                "\nUsers: " + GameMode.TeamBeta.Members +
                "\nScore: " + GameMode.TeamBeta.Score +
                "\nTotal Kills: " + GameMode.TeamBeta.Kills +
                "\nTotal Deaths: " + GameMode.TeamBeta.Deaths +
                "\nCaptured Flag by: " + (GameMode.TeamBeta.Flag.PlayerCaptured == null ? "None" : $"{GameMode.TeamBeta.Flag.PlayerCaptured.Name}");
            statsList.Show(player);
        }

        [Command("switch", Shortcut = "switch")]
        private static void ChangeTeam(Player player)
        {
            GameMode.TeamAlpha.GetMessageTeamEnable(out var msgAlpha, false);
            GameMode.TeamBeta.GetMessageTeamEnable(out var msgBeta, false);
            var ct = new TablistDialog("Change Team", 
                new[] { 
                    "Name",
                    "Users",
                    "Availability"
                }, "Seleccionar", "Cerrar");
            ct.Add(new[]
            {
                $"{GameMode.TeamAlpha.OtherColor}{GameMode.TeamAlpha.NameTeam}",
                $"{GameMode.TeamAlpha.OtherColor}{GameMode.TeamAlpha.Members}",
                $"{GameMode.TeamAlpha.OtherColor}{msgAlpha}"
            });

            ct.Add(new[]
            {
                $"{GameMode.TeamBeta.OtherColor}{GameMode.TeamBeta.NameTeam}",
                $"{GameMode.TeamBeta.OtherColor}{GameMode.TeamBeta.Members}",
                $"{GameMode.TeamBeta.OtherColor}{msgBeta}"
            });
            ct.Show(player);
            ct.Response += ChangeTeamDialog_Response;
        }

        public static void ChangeTeamDialog_Response(object sender, DialogResponseEventArgs e)
        {
            if(e.DialogButton == DialogButton.Left)
            {
                var player = e.Player as Player;
                var ct = sender as TablistDialog;
                if (player.PlayerTeam.Id == (TeamID)e.ListItem)
                {
                    player.SendClientMessage(Color.Red, "Error: Ya formas parte de ese equipo.");
                    ct.Show(player);
                    return;
                }
                --player.PlayerTeam.Members;
                if(player.PlayerTeam.TeamRival.IsFull())
                {
                    player.SendClientMessage(Color.Red, "Error: El equipo no está disponible.");
                    ++player.PlayerTeam.Members;
                    ct.Show(player);
                    return;
                }
                player.PlayerTeam = (e.ListItem == 0) ? GameMode.TeamAlpha : GameMode.TeamBeta;
                ++player.PlayerTeam.Members;
                BasePlayer.SendClientMessageToAll($"{player.PlayerTeam.OtherColor}[Team {player.PlayerTeam.NameTeam}]: {player.Name} se cambió al equipo {player.PlayerTeam.NameTeam}.");
                player.Spawn();
            }
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
