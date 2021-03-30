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
using SampSharp.GameMode.Controllers;
using CaptureTheFlag.Utils;

namespace CaptureTheFlag.DataBase.PlayerAccount
{
    [Controller]
    public partial class Account : IEventListener
    {
        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerConnected += (sender, e) =>
            {
                var player = sender as Player;
                try
                {
                    DateTime? expiryDate;
                    if((expiryDate = IsBanned(player)) != null)
                    {
                        if (expiryDate > DateTime.Now)
                        {
                            player.SendClientMessage(Color.Red, $"* Esta cuenta está prohíbida. La cuenta quedará desbloqueada en esta fecha y hora: {ParseData.ToStringDateTime((DateTime)expiryDate)}.");
                            player.Kick();
                            return;
                        }
                        DeleteBan(player.Name);
                    }

                    if (Load(player, out var password))
                    {
                        player.Account = AccountState.Login;
                        player.ShowDialogLogin(password);
                    }
                    else
                    {
                        player.Account = AccountState.Register;
                        player.ShowDialogRegister();
                    }
                }
                catch(MySqlException ex)
                {
                    player.SendErrorMessage(ex);
                }
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
            cmd.CommandText = $"INSERT INTO players(namePlayer, pass, totalKills, totalDeaths, killingSprees, levelGame, droppedFlags, headshots, registryDate, lastConnection) VALUES('{player.Name}', SHA2(@password, 256), 0, 0, 0, 1, 0, 0, @registryDate, NULL);";
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@registryDate", player.Data.RegistryDate);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            player.Data.AccountNumber = cmd.LastInsertedId;
        }

        public static bool Load(Player player, out string password)
        {
            cmd.CommandText = $"call getPlayerInfo('{player.Name}');";
            using var reader = cmd.ExecuteReader();
            bool exists = reader.Read();
            if (exists)
            {
                password = reader.GetString("password");
                player.Data.AccountNumber = reader.GetInt32("accountNumber");
                player.Data.TotalKills = reader.GetInt32("totalKills");
                player.Data.TotalDeaths = reader.GetInt32("totalDeaths");
                player.Data.KillingSprees = reader.GetInt32("killingSprees");
                player.Data.LevelGame = reader.GetInt32("levelGame");
                player.Data.DroppedFlags = reader.GetInt32("droppedFlags");
                player.Data.Headshots = reader.GetInt32("headshots");
                player.Data.RegistryDate = reader.GetDateTime("registryDate");
                player.Data.LevelAdmin = reader.GetInt32("levelAdmin");
                player.Data.LevelVip = reader.GetInt32("levelVip");
                player.Data.SkinId = reader.GetInt32("skinid");
            }
            else
                password = null;
            return exists;
        }

        public static string Encrypt(string text)
        {
            cmd.CommandText = $"SELECT SHA2(@text, 256);";
            cmd.Parameters.AddWithValue("@text", text);
            string password = (string)cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return password;
        }
    }  
}
   