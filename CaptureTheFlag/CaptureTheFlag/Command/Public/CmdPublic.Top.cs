using CaptureTheFlag.DataBase;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Public
{
    public partial class CmdPublic
    {
        [Command("top", Shortcut = "top")]
        public static void TopTen(Player player)
        {
            var dialogTop = new ListDialog("Top Ten", "Seleccionar", "Cerrar");
            var topten = new Top() { Sender = player, DialogMain = dialogTop };
            dialogTop.AddItems(new[] 
            { 
                "Total Kills",
                "Total Deaths",
                "Killing Sprees",
                "Headshots",
                "Dropped Flags"
            });
            dialogTop.Response += (sender, e) =>
            {
                if(e.DialogButton == DialogButton.Left)
                {
                    switch(e.ListItem)
                    {
                        case 0:
                            topten.ShowTopTen("totalKills", "Total Kills");
                            break;
                        case 1:
                            topten.ShowTopTen("totalDeaths", "Total Deaths");
                            break;
                        case 2:
                            topten.ShowTopTen("killingSprees", "Killing Sprees");
                            break;
                        case 3:
                            topten.ShowTopTen("headshots", "Headshots");
                            break;
                        case 4:
                            topten.ShowTopTen("droppedFlags", "Dropped Flags");
                            break;
                    }
                }
            };
            dialogTop.Show(player);
        }
    }
}
