using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Vip
{
    [CommandGroup("vip", PermissionChecker = typeof(BlockCommand))]
    public partial class CmdVip
    {
        [Command("test", Shortcut = "test")]
        public static void Test(Player player)
        {
            if (player.IsVipLevel(1)) return;
            //code..
        }

    }
}
