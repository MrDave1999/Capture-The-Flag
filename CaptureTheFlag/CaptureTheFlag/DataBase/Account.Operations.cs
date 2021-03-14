using CaptureTheFlag.PropertiesPlayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DBCommand;

namespace CaptureTheFlag.DataBase
{
    public partial class Account
    {
        public static void Update<T>(string campus, T newvalue, long accountNumber)
        {
            cmd.CommandText = $"UPDATE players SET {campus}=@{campus} WHERE accountNumber = @accountNumber;";
            cmd.Parameters.AddWithValue("@" + campus, newvalue);
            cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void Update<T>(string campus, T newvalue, string nameplayer, string nametable)
        {
            cmd.CommandText = $"UPDATE {nametable} SET {campus}=@{campus} WHERE namePlayer = @name_player;";
            cmd.Parameters.AddWithValue("@" + campus, newvalue);
            cmd.Parameters.AddWithValue("@name_player", nameplayer);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void Delete(Player player, string tablename)
        {
            cmd.CommandText = $"DELETE FROM {tablename} WHERE namePlayer = '{player.Name}';";
            cmd.ExecuteNonQuery();
        }
    }
}

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player
    {
        public void UpdateData<T>(string campus, T newvalue) 
            => DataBase.Account.Update(campus, newvalue, Data.AccountNumber);
    }
}
