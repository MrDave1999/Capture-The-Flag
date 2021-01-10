using CaptureTheFlag.PropertiesPlayer;
using MySql.Data.MySqlClient;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DBCommand;

namespace CaptureTheFlag.DataBase
{
    [CommandGroup("db", PermissionChecker = typeof(BlockCommand))]
    public partial class Account
    {
        [Command("changepass", Shortcut = "changepass", UsageMessage = "/changepass [password]")]
        public static void ChangePassword(Player player, string newpassword)
        {
            Validate.PasswordRange(player, newpassword);
            Update("pass", Encrypt(newpassword), player.Name);
            player.SendClientMessage(Color.Orange, $"** La nueva contraseña de tu cuenta es: {newpassword}");
        }

        [Command("changename", Shortcut = "changename", UsageMessage = "/changename [name]")]
        public static void ChangeName(Player player, string newname)
        { //The name to set. Must be 1-24 characters long and only contain valid characters (0-9, a-z, A-Z, [], (), \$ @ . _ and = only).
            if (newname.Length < 3 || newname.Length > 20)
            {
                player.SendClientMessage(Color.Red, "Error: La longitud del nombre debe tener entre 3 y 20 caracteres.");
                return;
            }

            BasePlayer.SendClientMessageToAll(Color.Yellow, $"[Anuncio]: {Color.Orange}{player.Name} cambió su nombre a {newname}");
            Update("namePlayer", newname, player.Name);
            player.Name = newname;
        }

        [Command("statsdb", Shortcut = "statsdb", UsageMessage = "/statsdb [playername]")]
        public static void StatsDb(Player player, string playername)
        {
            MySqlDataReader reader;
            int level;
            if(!Exists(playername))
            {
                player.SendClientMessage(Color.Red, "Error: Ese nombre no se encuentra en la base de datos del servidor.");
                return;
            }
            cmd.CommandText = "SELECT * FROM Players WHERE namePlayer = @namePlayer;";
            cmd.Parameters.AddWithValue("@namePlayer", playername);
            reader = cmd.ExecuteReader();
            reader.Read();
            var stats = new TablistDialog("Stats", 2, "Aceptar", "");
            stats.Add(new[] { "Name", reader.GetString("namePlayer") });
            stats.Add(new[] { "Account Number", reader.GetInt32("accountNumber").ToString() });
            stats.Add(new[] { "Registry Date", reader.GetDateTime("registryDate").ToString() });
            stats.Add(new[] { "Total Kills", reader.GetInt32("totalKills").ToString() });
            stats.Add(new[] { "Total Deaths", reader.GetInt32("totalDeaths").ToString() });
            stats.Add(new[] { "Killing Sprees", reader.GetInt32("killingSprees").ToString() });
            level = reader.GetInt32("levelGame");
            stats.Add(new[] { "Game Level", level.ToString() });
            stats.Add(new[] { "Rank", Rank.GetRankLevel(level) });
            stats.Add(new[] { "Next Rank", Rank.GetNextRankLevel(level) });
            stats.Add(new[] { "Dropped Flags", reader.GetInt32("droppedFlags").ToString() });
            stats.Add(new[] { "Headshots", reader.GetInt32("headshots").ToString() });
            stats.Show(player);
            cmd.Parameters.Clear();
            reader.Close();
        }
    }
}
