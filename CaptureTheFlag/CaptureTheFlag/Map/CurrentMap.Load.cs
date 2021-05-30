using CaptureTheFlag.Constants;
using CaptureTheFlag.Utils;
using IniParser;
using SampSharp.GameMode;
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

        public static void LoadConfigMap()
        {
            try
            {
                var dini = new Dini("config.ini", "Map");
                MAX_MAPS = int.Parse(dini.Read("MAX_MAPS"));
                MAX_TIME_ROUND = int.Parse(dini.Read("MAX_TIME_ROUND"));
                MAX_SPAWNS = int.Parse(dini.Read("MAX_SPAWNS"));
                MAX_TIME_LOADING = int.Parse(dini.Read("MAX_TIME_LOADING"));
                LoadMapNames();
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
                mapName = new string[MAX_MAPS];
                string[] fileEntries = Directory.GetFiles(Scriptfiles.GetPath("spawn_position"));
                int len = fileEntries.Length;
                for (int i = 0; i < len; ++i)
                    mapName[i] = Path.GetFileName(fileEntries[i]).Replace(".txt", "");
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

        public static void LoadSpawnPositions()
        {
            try
            {
                var sectionFile = new SectionFile($"spawn_position{Path.DirectorySeparatorChar}{GetCurrentMap()}.txt");
                LoadPositionsTeam(sectionFile, TeamID.Alpha);
                LoadPositionsTeam(sectionFile, TeamID.Beta);
                var sectionInterior = sectionFile.GetContentSection("Interior");
                Interior = sectionInterior != null ? int.Parse(sectionInterior[0]) : 0;
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

        public static void LoadPositionsTeam(SectionFile sectionFile, TeamID teamId)
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
