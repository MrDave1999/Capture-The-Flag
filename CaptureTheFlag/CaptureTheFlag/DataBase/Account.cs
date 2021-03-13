using MySql.Data.MySqlClient;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using System;
using System.Collections.Generic;
using System.Text;
using CaptureTheFlag.Constants;
using SampSharp.GameMode.World;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Command.Public;
using static CaptureTheFlag.DataBase.DBCommand;
using SampSharp.GameMode.SAMP.Commands;
using System.Globalization;

namespace CaptureTheFlag.DataBase
{
    public partial class Account
    {
        public Account()
        {
            BaseMode.Instance.PlayerConnected += (sender, e) =>
            {
                var player = sender as Player;
                if (Load(player, out var password))
                {
                    player.Account = AccountState.Login;
                    ShowDialogLogin(player, password);
                }
                else
                {
                    player.Account = AccountState.Register;
                    ShowDialogRegister(player);
                }
            };
        }

        public static void ShowDialogRegister(Player player)
        {
            var register = new InputDialog($"{Color.Yellow}Regístrate", $"Esta cuenta no está registrada.\nIngrese una contraseña:", true, "Aceptar", "");
            register.Show(player);
            register.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    Validate.IsEmpty(player, register, e.InputText);
                    Validate.PasswordRange(player, register, e.InputText);
                    Create(player, e.InputText);
                    CmdPublic.Help(player);
                    player.Account = AccountState.None;
                    player.SendClientMessage(Color.Orange, $"[Cuenta]: {Color.Yellow}Te has registrado de forma exitosa. {Color.Orange}Contraseña: {e.InputText}");
                }
                else
                    register.Show(player);

            };
        }

        public static void ShowDialogLogin(Player player, string password)
        {
            var login = new InputDialog($"{Color.Orange}Iniciar Sesión", "Esta cuenta sí está registrada.\nIngrese una contraseña:", true, "Aceptar", "");
            login.Show(player);
            login.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    Validate.IsEmpty(player, login, e.InputText);
                    Validate.PasswordRange(player, login, e.InputText);
                    if (password != Encrypt(e.InputText))
                    {
                        login.Message = "La contraseña que ingresaste es incorrecta.\nIngrese una contraseña:";
                        login.Show(player);
                        return;
                    }
                    LoadAdminLevel(player);
                    LoadVipLevel(player);
                    if (player.Data.LevelVip == 3)
                        player.Adrenaline = 100;
                    CmdPublic.StatsPlayer(player);
                    player.Account = AccountState.None;
                    player.SendClientMessage(Color.Orange, $"[Cuenta]: {Color.Yellow}Has iniciado sesión de forma exitosa!");
                    Player.AddLevels(player);
                }
                else
                    login.Show(player);
            };
        }

        public static bool Exists(string playername)
        {
            cmd.CommandText = $"SELECT namePlayer FROM players WHERE namePlayer = '{playername}';";
            using var reader = cmd.ExecuteReader();
            bool exists = reader.Read();
            return exists;
        }

        public static void Create(Player player, string password)
        {
            player.Data.RegistryDate = DateTime.Now;
            cmd.CommandText = $"INSERT INTO players(namePlayer, pass, totalKills, totalDeaths, killingSprees, levelGame, droppedFlags, headshots, registryDate, lastConnection) VALUES('{player.Name}', SHA2(@pass, 256), 0, 0, 0, 1, 0, 0, @registryDate, NULL);";
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@registryDate", player.Data.RegistryDate);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            player.Data.AccountNumber = cmd.LastInsertedId;
        }

        public static bool Load(Player player, out string password)
        {
            cmd.CommandText = $"SELECT * FROM players WHERE namePlayer = '{player.Name}';";
            using var reader = cmd.ExecuteReader();
            bool exists = reader.Read();
            if (exists)
            {
                password = reader.GetString("pass");
                player.Data.AccountNumber = reader.GetInt32("accountNumber");
                player.Data.TotalKills = reader.GetInt32("totalKills");
                player.Data.TotalDeaths = reader.GetInt32("totalDeaths");
                player.Data.KillingSprees = reader.GetInt32("killingSprees");
                player.Data.LevelGame = reader.GetInt32("levelGame");
                player.Data.DroppedFlags = reader.GetInt32("droppedFlags");
                player.Data.Headshots = reader.GetInt32("headshots");
                player.Data.RegistryDate = reader.GetDateTime("registryDate");
            }
            else
                password = null;
            return exists;
        }

        public static string Encrypt(string text)
        {
            cmd.CommandText = "SELECT SHA2(@text, 256);";
            cmd.Parameters.AddWithValue("@text", text);
            string str = (string)cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return str;
        }
    }  
}

namespace CaptureTheFlag.Command.Public
{
    public partial class CmdPublic
    {
        [Command("statsdb", Shortcut = "statsdb", UsageMessage = "/statsdb [playername]")]
        public static void StatsDb(Player player, string playername)
        {
            cmd.CommandText = $"SELECT * FROM players WHERE namePlayer = '{playername}';";
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var stats = new TablistDialog("Stats", 2, "Aceptar", "");
                var id = reader.GetInt32("accountNumber");
                stats.Add(new[] { "Name", reader.GetString("namePlayer") });
                stats.Add(new[] { "Account Number", id.ToString() });
                stats.Add(new[] { "Registry Date", ParseData.ToStringDateTime(reader.GetDateTime("registryDate"))});
                stats.Add(new[] { "Last Connection", 
                    !Player.IsPlayerOnline(id) ? ParseData.ToStringTime(reader.GetDateTime("lastConnection")) : "Connected" });
                stats.Add(new[] { "Total Kills", reader.GetInt32("totalKills").ToString() });
                stats.Add(new[] { "Total Deaths", reader.GetInt32("totalDeaths").ToString() });
                stats.Add(new[] { "Killing Sprees", reader.GetInt32("killingSprees").ToString() });
                int level = reader.GetInt32("levelGame");
                stats.Add(new[] { "Game Level", level.ToString() });
                stats.Add(new[] { "Rank", Rank.GetRankLevel(level) });
                stats.Add(new[] { "Next Rank", Rank.GetNextRankLevel(level) });
                stats.Add(new[] { "Dropped Flags", reader.GetInt32("droppedFlags").ToString() });
                stats.Add(new[] { "Headshots", reader.GetInt32("headshots").ToString() });
                stats.Show(player);
            }
            else
                player.SendClientMessage(Color.Red, "Error: Ese nombre no se encuentra en la base de datos del servidor.");
        }
    }
}
   