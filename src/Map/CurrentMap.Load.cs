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
using DotEnv.Core;

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
            MAX_TIME_ROUND = int.Parse(EnvReader.Instance["MAX_TIME_ROUND"]);
            MAX_SPAWNS = int.Parse(EnvReader.Instance["MAX_SPAWNS"]);
            MAX_TIME_LOADING = int.Parse(EnvReader.Instance["MAX_TIME_LOADING"]);
            DEFAULT_INTERIOR = int.Parse(EnvReader.Instance["INTERIOR"]);
            DEFAULT_WEATHER = int.Parse(EnvReader.Instance["WEATHER"]);
            DEFAULT_WORLDTIME = int.Parse(EnvReader.Instance["WORLD_TIME"]);
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
                Interior = Int(sectionFile.GetContentSection("Interior")?[0]) ?? DEFAULT_INTERIOR;
                Weather = Int(sectionFile.GetContentSection("Weather")?[0]) ?? DEFAULT_WEATHER;
                WorldTime = Int(sectionFile.GetContentSection("WorldTime")?[0]) ?? DEFAULT_WORLDTIME;
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
                spawns[(int)teamId, i].X = Double(position[0]);
                spawns[(int)teamId, i].Y = Double(position[1]);
                spawns[(int)teamId, i].Z = Double(position[2]);
                spawns[(int)teamId, i].Angle = Float(position[3]);
            }
        }
    }
}
