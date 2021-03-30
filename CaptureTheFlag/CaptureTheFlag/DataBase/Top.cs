using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using static CaptureTheFlag.DataBase.DBCommand;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CaptureTheFlag.DataBase
{
    public class Top
    {
        /* It save the main menu instance. */
        public ListDialog DialogMain { get; set; }
        /* It save the instance of the player who entered the main dialog TopTen. */
        public Player Sender { get; set; }

        public void ShowTopTen(string campus, string nameColumn)
        {
            try
            {
                int position = 0;
                var dialogTop = new TablistDialog("Top Ten", new[] { "Position", "Name", $"{nameColumn}" }, "Atrás", "Cerrar");
                cmd.CommandText = $"SELECT namePlayer, {campus} FROM players ORDER BY {campus} DESC LIMIT 10;";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dialogTop.Add(new[] { $"#{++position}", reader.GetString("namePlayer"), reader.GetInt32(campus).ToString() });
                dialogTop.Response += (s, e) =>
                {
                    if (e.DialogButton == DialogButton.Left)
                        DialogMain.Show(Sender);
                };
                dialogTop.Show(Sender);
            }
            catch (MySqlException e)
            {
                Sender.SendErrorMessage(e);
            }
        }
    }
}
