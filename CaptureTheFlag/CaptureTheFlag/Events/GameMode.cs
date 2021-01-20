using System;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.SAMP;
using CaptureTheFlag.Textdraw;
using CaptureTheFlag.Controller;
using CaptureTheFlag.Map;
using static CaptureTheFlag.Map.CurrentMap;
using CaptureTheFlag.Constants;
using CaptureTheFlag.DataBase;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        public static Team TeamAlpha { get; set; }
        public static Team TeamBeta { get; set; }
        public static readonly uint ColorWhite = 0xFFFFFF00;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e); 
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" GameMode Capture The Flag");
            Console.WriteLine("     Team DeathMatch");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("CTF ~v5.8.2-beta3");
            Server.SendRconCommand("hostname .:: Capture The Flag ::. |Team DeathMatch|");
            Server.SendRconCommand("weburl www.");
            Server.SendRconCommand("language  Español Latino");
            Server.SendRconCommand("loadfs EntryMap");
            Server.SendRconCommand("loadfs RemoveBuilding");
            //UsePlayerPedAnimations();
            DisableInteriorEnterExits();

            AddPlayerClass(SkinTeam.Alpha, new Vector3(0, 0, 0), 0);
            AddPlayerClass(SkinTeam.Beta, new Vector3(0, 0, 0), 0);

            StartTimer();
            TeamAlpha = new Team(SkinTeam.Alpha, "{FF2040}", "~r~", TextDrawGlobal.TdScoreAlpha, TeamID.Alpha, "Alpha", "Roja", new Flag(FlagID.Alpha, Color.Red, FileRead.FlagPositionRead("Red")), Interior);
            TeamBeta =  new Team(SkinTeam.Beta,  "{0088FF}", "~b~", TextDrawGlobal.TdScoreBeta,  TeamID.Beta,  "Beta",  "Azul", new Flag(FlagID.Beta, Color.Blue, FileRead.FlagPositionRead("Blue")), Interior);
            TeamAlpha.TeamRival = TeamBeta;
            TeamBeta.TeamRival = TeamAlpha;
            Server.SendRconCommand($"mapname {GetCurrentMap()}");
            Server.SendRconCommand($"loadfs {GetCurrentMap()}");

            new DBCommand();
            new Account();
        }

        protected override void OnExited(EventArgs e)
        {
            base.OnExited(e);
            DBConnect.Close();
        }
      
        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            controllers.Override(new PlayerController());
        }
    }
}