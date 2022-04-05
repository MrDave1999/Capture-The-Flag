using CaptureTheFlag.Teams;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.Map.CurrentMap;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnExited(EventArgs e)
        {
            base.OnExited(e);
            Server.SendRconCommand("unloadfs EntryMap");
            Server.SendRconCommand("unloadfs RemoveBuilding");
            Server.SendRconCommand($"unloadfs {GetCurrentMap()}");
            Flag.RemoveAll();
            TeamAlpha.Icon.Dispose();
            TeamBeta.Icon.Dispose();
            TimerLeft.Dispose();
            TextDrawGlobal.Destroy();
            TextDrawEntry.Destroy();
            Console.WriteLine("  The gamemode was unloading correctly.");
        }
    }
}
