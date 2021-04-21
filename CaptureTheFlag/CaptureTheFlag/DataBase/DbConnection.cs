using MySql.Data.MySqlClient;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using static CaptureTheFlag.DataBase.DbCommand;
 
namespace CaptureTheFlag.DataBase
{
    [Controller]
    public class DbConnection : IEventListener
    {
        public static string ConnectionString { get; set; }
        public static MySqlConnection Connection { get; set; }

        public void RegisterEvents(BaseMode gameMode) =>
            gameMode.Initialized += (sender, e) => CheckConnection();

        public static void CheckConnection()
        {
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["CTF"].ConnectionString;
                Connection = new MySqlConnection(ConnectionString);
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
