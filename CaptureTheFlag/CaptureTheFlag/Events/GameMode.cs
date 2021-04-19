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
using System.IO;
using System.Configuration;
using System.Reflection;
using CaptureTheFlag.Teams;
using IniParser;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        public static Team TeamAlpha { get; set; }
        public static Team TeamBeta { get; set; }
        public static readonly uint ColorWhite = 0xFFFFFF00;
        private static string hiddenCommand;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e); 
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" GameMode Capture The Flag");
            Console.WriteLine("     Team DeathMatch");
            Console.WriteLine("----------------------------------\n");

            Server.SendRconCommand("loadfs EntryMap");
            Server.SendRconCommand("loadfs RemoveBuilding");
            //UsePlayerPedAnimations();
            DisableInteriorEnterExits();
            AddPlayerClass(SkinTeam.Alpha, new Vector3(0, 0, 0), 0);
            AddPlayerClass(SkinTeam.Beta, new Vector3(0, 0, 0), 0);
            TextDrawGlobal.Create();
            TextDrawEntry.Create();

            try
            {
                var data = new IniDataParser().Parse(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "scriptfiles/config_server.ini")));
                Server.SendRconCommand($"hostname {data["server"]["hostname"]}");
                Server.SendRconCommand($"language {data["server"]["language"]}");
                hiddenCommand = data["server"]["hidden_command"];
                SetGameModeText(data["server"]["gamemode_text"]);
                StartTimer(data["server"]["name_map"]);
                Console.WriteLine("  config_server.ini loaded successfully!");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error {ex.StackTrace} Reason: {ex.Message}");
            }

            TeamAlpha = new Team(
                skin: SkinTeam.Alpha, 
                otherColor: "{FF2040}", 
                colorGameText: "~r~", 
                TextDrawGlobal.TdScoreAlpha, 
                teamid: TeamID.Alpha, 
                name: "Alpha", 
                namecolor: "Roja", 
                colorEnglish: "Red",
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
                colorEnglish: "Blue",
                new Flag(FlagID.Beta, Color.Blue, FileRead.FlagPositionRead("Blue")), 
                Interior
            );
            TeamAlpha.TeamRival = TeamBeta;
            TeamBeta.TeamRival = TeamAlpha;
            Server.SendRconCommand($"mapname {GetCurrentMap()}");
            Server.SendRconCommand($"loadfs {GetCurrentMap()}");
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
            Console.WriteLine("  The gamemode was unloading correctly.");
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