using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.SAMP.Commands;

namespace CaptureTheFlag.Command.Admin
{
    [CommandGroup("admin", PermissionChecker = typeof(BlockCommand))]
    public partial class CmdAdmin
    {
        [Command("admins", Shortcut = "admins")]
        private static void ListAdmins(Player player)
        {

        }

        [Command("report", Shortcut = "report", UsageMessage = "/report [playerid] [reason]")]
        private static void SendReport(Player player)
        {

        }
    }
}
