using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.Utils.Rand;
using static SampSharp.GameMode.World.BasePlayer;
using CaptureTheFlag.Constants;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Utils;
using System.IO;

namespace CaptureTheFlag.Map
{
    public partial class CurrentMap
    {
        /* *** Constants */
        public static int MAX_SPAWNS;
        public static int MAX_TIME_ROUND;
        public static int MAX_TIME_LOADING;
        public static int MAX_MAPS;
        /* ** */

        public static int timeLeft;
        
        public static int Id { get; set; }
        public static int Interior { get; set; }
        public static bool IsLoading { get; set; }
        public static int ForceMap { get; set; } = -1;
        public static SpawnPoint[,] spawns;
        public static string[] mapName;
        public static Timer TimerLeft;

        public static void StartTimer(string nameMap)
        {
            LoadConfigMap();
            TimerLeft = new Timer(1000, true);
            TextDraw tdTimeLeft = TextDrawGlobal.TdTimeLeft;
            int timeLoading = MAX_TIME_LOADING;
            timeLeft = MAX_TIME_ROUND;
            Id = (nameMap == null) ? Next(MAX_MAPS) : GetMapId(nameMap);
            spawns = new SpawnPoint[2, MAX_SPAWNS];
            for (int i = 0; i < MAX_SPAWNS; ++i)
                spawns[(int)TeamID.Alpha, i] = new SpawnPoint();
            for (int i = 0; i < MAX_SPAWNS; ++i)
                spawns[(int)TeamID.Beta, i] = new SpawnPoint();
            LoadSpawnPositions();
            TimerLeft.Tick += (sender, e) =>
            {
                if (timeLeft < 0)
                {
                    if (timeLoading == MAX_TIME_LOADING)
                        OnLoadingMap();
                    else if (timeLoading < 0)
                    {
                        OnLoadedMap();
                        timeLoading = MAX_TIME_LOADING;
                        return;
                    }
                    GameTextForAll($"Cargando Mapa... ({timeLoading})", 99999999, 3);
                    --timeLoading;
                }
                else
                {
                    tdTimeLeft.Text = $"{timeLeft / 60:D2}:{timeLeft % 60:D2}";
                    --timeLeft;
                }
            };
        }

        public static void SetPlayerPosition(Player player)
        {
            int teamid = player.Team;
            int rand = Next(MAX_SPAWNS);
            player.Position = new Vector3(spawns[teamid, rand].X, spawns[teamid, rand].Y, spawns[teamid, rand].Z);
            player.Angle = spawns[teamid, rand].Angle;
            player.Interior = Interior;
        }

        public static string GetMapName(int mapid) => mapName[mapid];
        public static string GetCurrentMap() => mapName[Id];
        public static int GetMapId(string nameSearch)
        {
            int len = mapName.Length;
            for (int i = 0; i != len; ++i)
                if(nameSearch.Equals(mapName[i], StringComparison.OrdinalIgnoreCase))
                    return i;
            return 0;
        }
    }
}
