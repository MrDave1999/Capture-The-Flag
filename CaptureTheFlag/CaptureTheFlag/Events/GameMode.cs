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
using SampSharp.GameMode.Events;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.World;

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

            SetGameModeText("CTF ~v6.1.4");
            Server.SendRconCommand("hostname .:: Capture The Flag ::. |Team DeathMatch|");
            Server.SendRconCommand("weburl www.");
            Server.SendRconCommand("language  Español Latino");
            Server.SendRconCommand("loadfs EntryMap");
            Server.SendRconCommand("loadfs RemoveBuilding");
            //UsePlayerPedAnimations();
            DisableInteriorEnterExits();
            AddPlayerClass(SkinTeam.Alpha, new Vector3(0, 0, 0), 0);
            AddPlayerClass(SkinTeam.Beta, new Vector3(0, 0, 0), 0);
            TextDrawGlobal.Create();
            TextDrawEntry.Create();
            StartTimer();
            TeamAlpha = new Team(
                skin: SkinTeam.Alpha, 
                otherColor: "{FF2040}", 
                colorGameText: "~r~", 
                TextDrawGlobal.TdScoreAlpha, 
                teamid: TeamID.Alpha, 
                name: "Alpha", 
                namecolor: "Roja", 
                new Flag(FlagID.Alpha, Color.Red, FileRead.FlagPositionRead("Red")), 
                Interior
            );

            TeamBeta =  new Team(
                skin: SkinTeam.Beta,  
                otherColor: "{0088FF}", 
                colorGameText: "~b~", 
                TextDrawGlobal.TdScoreBeta,  
                teamid: TeamID.Beta,  
                name: "Beta",  
                namecolor: "Azul", 
                new Flag(FlagID.Beta, Color.Blue, FileRead.FlagPositionRead("Blue")), 
                Interior
            );
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
            Server.SendRconCommand("unloadfs EntryMap");
            Server.SendRconCommand("unloadfs RemoveBuilding");
            Server.SendRconCommand($"unloadfs {GetCurrentMap()}");
            Flag.RemoveAll();
            TeamAlpha.Icon.Dispose();
            TeamBeta.Icon.Dispose();
            DBConnect.Close();
            TimerLeft.Dispose();
            TextDrawGlobal.Destroy();
            TextDrawEntry.Destroy();
        }
      
        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            controllers.Override(new PlayerController());
        }

        protected override void OnRconLoginAttempt(RconLoginAttemptEventArgs e)
        {
            base.OnRconLoginAttempt(e);
            if (e.SuccessfulLogin) 
            {
                foreach(Player player in BasePlayer.GetAll<Player>())
                {
                    if(player.IsConnected && e.IP == player.IP && player.Data.LevelAdmin != 4)
                    {
                        player.SendClientMessage(Color.Red, "Error: Usted no tiene el rango necesario para iniciar como RCON.");
                        player.Kick();
                        break;
                    }
                }
            }
        }
    }
}