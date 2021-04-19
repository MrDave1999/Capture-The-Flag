using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
 
namespace CaptureTheFlag.DataBase
{
    public static class DbConnection
    {
        public static MySqlConnection Connection { get; set; }

        public static void Open()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["CTF"].ConnectionString;
                Connection = new MySqlConnection(cs);
                Connection.Open();
                Console.WriteLine("  The database connection was successful!");
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
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
