using System;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.SAMP;
using CaptureTheFlag.Textdraw;
using CaptureTheFlag.Controller;
using CaptureTheFlag.Map;
using static CaptureTheFlag.Map.CurrentMap;
using CaptureTheFlag.Constants;
using System.IO;
using System.Reflection;
using CaptureTheFlag.Teams;
using IniParser;
using CaptureTheFlag.Utils;
using DotEnv.Core;

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


            var envVars = new EnvLoader().Load(out var result);
            Console.WriteLine(result.ErrorMessages);
            Server.SendRconCommand($"hostname {envVars["HOSTNAME"]}");
            Server.SendRconCommand($"language {envVars["LANGUAGE"]}");
            hiddenCommand = envVars["HIDDEN_COMMAND"];
            SetGameModeText(envVars["GAMEMODE_TEXT"]);
            var mapName = envVars["MAPNAME"];
            StartTimer(string.IsNullOrWhiteSpace(mapName) ? null : mapName);

            TeamAlpha = new Team(
                skin: SkinTeam.Alpha, 
                otherColor: "{FF2040}", 
                colorGameText: "~r~", 
                TextDrawGlobal.TdScoreAlpha, 
                teamid: TeamID.Alpha, 
                name: "Alpha", 
                namecolor: "Roja", 
                colorEnglish: "Red",
                new Flag(FlagID.Alpha, Color.Red, LoadFlagPosition("Red")), 
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
                new Flag(FlagID.Beta, Color.Blue, LoadFlagPosition("Blue")), 
                Interior
            );
            TeamAlpha.TeamRival = TeamBeta;
            TeamBeta.TeamRival = TeamAlpha;
            Server.SendRconCommand($"mapname {GetCurrentMap()}");
            Server.SendRconCommand($"loadfs {GetCurrentMap()}");
            Server.SetWeather(Weather);
            Server.SetWorldTime(WorldTime);
            base.OnInitialized(e);
        }
      
        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            controllers.Override(new PlayerController());
        }
    }
}