using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.DataBase
{
    public static class DBConnect
    {
        public static MySqlConnection Connection { get; set; }

        public static void Open()
        {
            string cs = "server=localhost;port=3306;username=root;password=1234;database=gamemode;";
            try
            {
                Connection = new MySqlConnection(cs);
                Connection.Open();
                Console.WriteLine("  The database connection was successful!");
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public static void Close()
        {
            try
            {
                Connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
