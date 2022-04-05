using CaptureTheFlag.Utils;
using MySql.Data.MySqlClient;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using System;
using static CaptureTheFlag.DataBase.DbCommand;
using DotEnv.Core;

namespace CaptureTheFlag.DataBase
{
    [Controller]
    public class DbConnection : IEventListener
    {
        public static MySqlConnection Connection { get; set; }

        public void RegisterEvents(BaseMode gameMode) =>
            gameMode.Initialized += (sender, e) => CheckConnection();

        public static void CheckConnection()
        {
            try
            {
                Connection = new MySqlConnection(EnvReader.Instance["CONNECTION_STRING"]);
                cmd.Connection = Connection;
                using var con = CreateConnection();
                Console.WriteLine("  The database connection was successful!");
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }

        public static MySqlConnection CreateConnection()
        {
            Connection.Open();
            return Connection;
        }
    }
}
