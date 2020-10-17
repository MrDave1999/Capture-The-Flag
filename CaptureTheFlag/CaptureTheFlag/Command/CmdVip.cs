using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command
{
    [CommandGroup("vip", PermissionChecker = typeof(BlockCommand))]
    public class CmdVip
    {
        [Command("test", Shortcut = "test")]
        public static void Test(Player player)
        {

        }

    }
}
