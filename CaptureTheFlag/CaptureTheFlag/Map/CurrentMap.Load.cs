using CaptureTheFlag.Constants;
using CaptureTheFlag.Utils;
using IniParser;
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CaptureTheFlag.Utils.ParseData;

namespace CaptureTheFlag.Map
{
    public partial class CurrentMap
    {
        private static readonly string iniFlag;

        static CurrentMap()
        {
            try
            {
                iniFlag = File.ReadAllText(Scriptfiles.GetPath("flag_position.ini"));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }

        /* Load the general map configuration. */
        public static void LoadConfigMap()
        {
            try
            {
                var dini = new Dini("config.ini", "Map");
                MAX_TIME_ROUND = int.Parse(dini.Read("MAX_TIME_ROUND"));
                MAX_SPAWNS = int.Parse(dini.Read("MAX_SPAWNS"));
                MAX_TIME_LOADING = int.Parse(dini.Read("MAX_TIME_LOADING"));
                Interior = int.Parse(dini.Read("INTERIOR"));
                Weather = int.Parse(dini.Read("WEATHER"));
                WorldTime = int.Parse(dini.Read("WORLD_TIME"));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }

        public static void LoadMapNames()
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(Scriptfiles.GetPath("maps"));
                MAX_MAPS = fileEntries.Length;
                mapName = new string[MAX_MAPS];
                for (int i = 0; i < MAX_MAPS; ++i)
                    mapName[i] = Path.GetFileName(fileEntries[i]).Replace(".ini", "");
                Rand.Shuffle(mapName);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }

        public static Vector3 LoadFlagPosition(string section)
        {
            var data = new IniDataParser().Parse(iniFlag);
            string[] position = data[section][GetCurrentMap()].Split(',');
            return new Vector3(Double(position[0]), Double(position[1]), Double(position[2]));
        }

        /* Loads the specific data of a map. */
        public static void LoadMapData()
        {
            try
            {
                var path = Scriptfiles.GetPath($"maps{Path.DirectorySeparatorChar}{GetCurrentMap()}.ini");
                var sectionFile = new IniDataSection(path);
                LoadPositionsTeam(sectionFile, TeamID.Alpha);
                LoadPositionsTeam(sectionFile, TeamID.Beta);
                var sectionInterior = sectionFile.GetContentSection("Interior");
                var sectionWeather = sectionFile.GetContentSection("Weather");
                var sectionWorldTime = sectionFile.GetContentSection("WorldTime");
                Interior = sectionInterior != null ? int.Parse(sectionInterior[0]) : Interior;
                Weather = sectionWeather != null ? int.Parse(sectionWeather[0]) : Weather;
                WorldTime = sectionWorldTime != null ? int.Parse(sectionWorldTime[0]) : WorldTime;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }

        public static void LoadPositionsTeam(IniDataSection sectionFile, TeamID teamId)
        {
            var section = sectionFile.GetContentSection(teamId.ToString());
            string[] position;
            for (int i = 0; i < MAX_SPAWNS; ++i)
            {
                position = section[i].Split(',');
                spawns[(int)teamId, i].X         = Double(position[0]);
                spawns[(int)teamId, i].Y         = Double(position[1]);
                spawns[(int)teamId, i].Z         = Double(position[2]);
                spawns[(int)teamId, i].Angle     = Float (position[3]);
            }
        }
    }
}
