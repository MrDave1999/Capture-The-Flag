using CaptureTheFlag.Textdraw;
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
using static CaptureTheFlag.Events.GameMode;
using CaptureTheFlag.Constants;
using SampSharp.Streamer.World;
using CaptureTheFlag.PropertiesPlayer;
using System.Linq;
using CaptureTheFlag.Map;
using CaptureTheFlag.Permission;
using CaptureTheFlag.Data;

namespace CaptureTheFlag.Command.Public
{
    static class ExtensionTablistDialog
    {
        public static void SetInfo(this TablistDialog vs)
        {
            vs.Clear();
            TeamAlpha.GetMessageTeamEnable(out var msgAlpha, false);
            TeamBeta.GetMessageTeamEnable(out var msgBeta, false);
            vs.Add(new[]
            {       
                $"{TeamAlpha.OtherColor}{TeamAlpha.NameTeam}",
                $"{TeamAlpha.OtherColor}{TeamAlpha.Members}",
                $"{TeamAlpha.OtherColor}{msgAlpha}"
            });
            vs.Add(new[]
            {
                $"{TeamBeta.OtherColor}{TeamBeta.NameTeam}",
                $"{TeamBeta.OtherColor}{TeamBeta.Members}",
                $"{TeamBeta.OtherColor}{msgBeta}"
            });
        }

        public static void ShowDialog(this TablistDialog vs, Player player)
        {
            vs.SetInfo();
            vs.Show(player);
        }
    }
    
    [CommandGroup("public", PermissionChecker = typeof(BlockCommand))]
    public partial class CmdPublic
    {
        [Command("listplayers", Shortcut = "listplayers")]
        public static void ListPlayers(BasePlayer player)
        { //test command 
            player.SendClientMessage($"Players available: {BasePlayer.GetAll<BasePlayer>().Count()}");
            try
            {
                foreach (var p in BasePlayer.GetAll<BasePlayer>())
                {
                    player.SendClientMessage("Player: " + p.Name);
                }
            }
            catch (Exception e)
            {
                player.SendClientMessage(Color.Red, e.Message);
            }
        }

        [Command("re", Shortcut = "re")]
        private static void ResetScore(Player player)
        {
            player.Kills = 0;
            player.Deaths = 0;
            TextDrawPlayer.UpdateTdStats(player);
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"** {player.Name} ha reseteado su score con {Color.Red}/re");
        }

        [Command("kill", Shortcut = "kill")]
        private static void Kill(Player player)
        {
            if(player.Team == BasePlayer.NoTeam)
            {
                player.SendClientMessage(Color.Red, "Error: No puedes usar este comando.");
                return;
            }
            player.Health = 0;
        }

        [Command("datetime", Shortcut = "datetime")]
        private static void DateTimeServer(Player player) =>
            player.SendClientMessage(Color.Orange, $"--> Fecha y hora local del servidor: {Color.White}{DateTime.Now}");

        [Command("map", Shortcut = "map")]
        private static void MapName(Player player)
            => player.SendClientMessage(Color.Yellow, $"* Mapa actual: {Color.Orange}{CurrentMap.GetCurrentMap()}.");

        [Command("stop", Shortcut = "stop")]
        private static void StopMusic(Player player)
        {
            player.StopAudioStream();
            player.GameText("STOP MUSIC", 2000, 3);
        }

        [Command("music", Shortcut = "music")]
        private static void PlayMusic(Player player)
        {
            var music = new InputDialog(" ",
                $"{Color.Yellow}Escribe la URL para reproducir la música. Los formatos válidos son mp3 y ogg/vorbis." +
                "\nUn enlace a un archivo .pls (lista de reproducción) reproducirá esa lista de reproducción." +
                $"\n\n{Color.Orange}Se recomienda los siguientes convertidores a MP3:" +
                $"\n{Color.Yellow}notube.net" +
                "\nytmp3.cc", 
                false, "Reproducir", "Cerrar");
            music.Response += (sender, e) =>
            {
                if(e.DialogButton == DialogButton.Left)
                    player.PlayAudioStream(e.InputText);
            };
            music.Show(player);
        }

        [Command("ranks", Shortcut = "ranks")]
        private static void RanksDialog(Player player)
        {
            var ct = new TablistDialog("Ranks",
                new[] {
                    "Level",
                    "Rank",
                    "Total Kills Required"
                }, "Cerrar", "");
            for (int i = Rank.MAX_RANK; i != 0; --i)
                ct.Add(i.ToString(), Rank.GetRankLevel(i), Rank.GetRequiredKills(i).ToString());
            ct.Show(player);
        }

        [Command("switch", Shortcut = "switch")]
        private static void ChangeTeam(Player player)
        {
            if(player.Team == BasePlayer.NoTeam)
            {
                player.SendClientMessage(Color.Red, "Error: Usted no pertenece a ningún equipo.");
                return;
            }
            TeamAlpha.GetMessageTeamEnable(out var msgAlpha, false);
            TeamBeta.GetMessageTeamEnable(out var msgBeta, false);
            var ct = new TablistDialog("Change Team", 
                new[] { 
                    "Name",
                    "Users",
                    "Availability"
                }, "Seleccionar", "Cerrar");
            ct.ShowDialog(player);
            ct.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    if (player.PlayerTeam.Id == (TeamID)e.ListItem)
                    {
                        player.SendClientMessage(Color.Red, "Error: Ya formas parte de ese equipo.");
                        ct.ShowDialog(player);
                        return;
                    }
                    if(TeamAlpha.Members == TeamBeta.Members)
                    {
                        player.SendClientMessage(Color.Red, $"Error: No puedes cambiarte al equipo {(e.ListItem == 0 ? "Alpha" : "Beta")} porque el equipo {player.PlayerTeam.NameTeam} quedaría desequilibrado.");
                        ct.ShowDialog(player);
                        return;
                    }
                    if (player.PlayerTeam.TeamRival.IsFull())
                    {
                        player.SendClientMessage(Color.Red, "Error: El equipo no está disponible.");
                        ct.ShowDialog(player);
                        return;
                    }
                    if (player.IsCapturedFlag())
                        player.Drop();
                    Player.Remove(player);
                    player.PlayerTeam = (e.ListItem == 0) ? TeamAlpha : TeamBeta;
                    Player.Add(player);
                    BasePlayer.SendClientMessageToAll($"{player.PlayerTeam.OtherColor}[Team {player.PlayerTeam.NameTeam}]: {player.Name} se cambió al equipo {player.PlayerTeam.NameTeam}.");
                    TextDrawGlobal.UpdateCountUsers();
                    player.Spawn();
                }
            };
        }

        [Command("users", Shortcut = "users")]
        public static void UsersList(Player player)
        {
            var users = new TablistDialog(
                $"{TeamAlpha.OtherColor}Alpha: {TeamAlpha.Members} {TeamBeta.OtherColor}Beta: {TeamBeta.Members}",
                new[] {
                    "Id",
                    "Name",
                    "Kills",
                    "Deaths"
                }, "Cerrar", "");
            TeamAlpha.Players.Sort((a, b) => b.Kills - a.Kills);
            TeamBeta.Players.Sort((a, b) => b.Kills - a.Kills);
            foreach (Player player1 in TeamAlpha.Players)
                users.Add(player1.ToString());
            if(TeamAlpha.Members > 0)
                users.Add(" ", " ", " ", " ");
            foreach (Player player1 in TeamBeta.Players)
                users.Add(player1.ToString());
            users.Show(player);
        } 

        [Command("tc", Shortcut = "tc", UsageMessage = "/tc [message]")]
        public static void TeamChat(Player player, string msg)
        {
            if(player.Team == BasePlayer.NoTeam)
            {
                player.SendClientMessage(Color.Red, "Error: Debes estar en un equipo para usar el TeamChat.");
                return;
            }
            foreach(Player player1 in player.PlayerTeam.Players)
                player1.SendClientMessage($"{player.PlayerTeam.OtherColor}[Team Chat] {player.Name} [{player.Id}]: {msg}");
        }
    }
}
