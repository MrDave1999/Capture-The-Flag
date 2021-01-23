using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.DataBase
{
    public class DBCommand
    {
        public static MySqlCommand cmd;

        public DBCommand()
        {
            DBConnect.Open();
            cmd = new MySqlCommand() { Connection = DBConnect.Connection };
        }
    }
}
