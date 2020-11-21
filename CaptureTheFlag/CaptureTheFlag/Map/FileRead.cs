//define DEBUG
#undef DEBUG

using IniParser;
using SampSharp.GameMode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaptureTheFlag.Map
{
    public static class FileRead
    {
        private static readonly string iniFile;

        static FileRead()
        {
            iniFile = File.ReadAllText(GetPath("flag_position.ini"));
        }

        public static string GetPath(string part)
        {
        #if DEBUG
            return Path.Combine(@"C:\Users\syslan\Desktop\Capture-the-flag", "scriptfiles" + Path.DirectorySeparatorChar + part);
        #else
            return Path.Combine(Directory.GetCurrentDirectory(), "scriptfiles" + Path.DirectorySeparatorChar + part);
        #endif
        }

        public static void ConfigMapRead()
        {
            var data = new IniDataParser().Parse(File.ReadAllText(GetPath("config_maps.ini")));
            CurrentMap.MAX_MAPS = int.Parse(data["Map"]["MAX_MAPS"]);
            CurrentMap.MAX_TIME_ROUND = int.Parse(data["Map"]["MAX_TIME_ROUND"]);
            CurrentMap.MAX_SPAWNS = int.Parse(data["Map"]["MAX_SPAWNS"]);
            CurrentMap.MAX_TIME_LOADING = int.Parse(data["Map"]["MAX_TIME_LOADING"]);
        }

        public static void NamesMapRead()
        {
            string[] lines = File.ReadAllLines(GetPath("names_maps.txt"));
            int len = lines.Length;
            for(int i = 0; i < len; ++i)
                CurrentMap.mapName[i] = lines[i];
        }

        public static Vector3 FlagPositionRead(string section)
        {
            var data = new IniDataParser().Parse(iniFile);
            string[] position = data[section][CurrentMap.GetCurrentMap()].Split(',');
            return new Vector3(ParseData.Double(position[0]), ParseData.Double(position[1]), ParseData.Double(position[2]));
        }

        public static void SpawnPositionRead()
        {
            string[] lines = File.ReadAllLines(GetPath($"spawn_position{Path.DirectorySeparatorChar}{CurrentMap.GetCurrentMap()}.txt"));
            string[] position;
            int len = lines.Length - 1;
            int j = 0;
            CurrentMap.Interior = int.Parse(lines[len]);
            for(int i = 0; i < CurrentMap.MAX_SPAWNS; ++i)
            {
                position = lines[i].Split(',');
                CurrentMap.spawns[(int)TeamID.Alpha, i].X = ParseData.Double(position[0]);
                CurrentMap.spawns[(int)TeamID.Alpha, i].Y = ParseData.Double(position[1]);
                CurrentMap.spawns[(int)TeamID.Alpha, i].Z = ParseData.Double(position[2]);
                CurrentMap.spawns[(int)TeamID.Alpha, i].Angle = ParseData.Float(position[3]);
            }

            for (int i = CurrentMap.MAX_SPAWNS + 1; i < len; ++i)
            {
                position = lines[i].Split(',');
                CurrentMap.spawns[(int)TeamID.Beta, j].X = ParseData.Double(position[0]);
                CurrentMap.spawns[(int)TeamID.Beta, j].Y = ParseData.Double(position[1]);
                CurrentMap.spawns[(int)TeamID.Beta, j].Z = ParseData.Double(position[2]);
                CurrentMap.spawns[(int)TeamID.Beta, j++].Angle = ParseData.Float(position[3]);
            }
        }
    }
}
