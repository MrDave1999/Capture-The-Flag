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
            DbConnection.Open();
            cmd = new MySqlCommand() { Connection = DbConnection.Connection };
        }
    }
}
