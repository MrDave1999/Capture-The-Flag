using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.DataBase
{
    public class DbCommand
    {
        public static MySqlCommand cmd;

        public DbCommand()
        {
            DBConnect.Open();
            cmd = new MySqlCommand() { Connection = DBConnect.Connection };
        }
    }
}
