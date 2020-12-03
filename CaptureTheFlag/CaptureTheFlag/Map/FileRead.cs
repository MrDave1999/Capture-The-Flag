﻿//define DEBUG
#undef DEBUG

using IniParser;
using SampSharp.GameMode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CaptureTheFlag.Map.CurrentMap;
using static CaptureTheFlag.ParseData;
using CaptureTheFlag.Constants;

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
            MAX_MAPS = int.Parse(data["Map"]["MAX_MAPS"]);
            MAX_TIME_ROUND = int.Parse(data["Map"]["MAX_TIME_ROUND"]);
            MAX_SPAWNS = int.Parse(data["Map"]["MAX_SPAWNS"]);
            MAX_TIME_LOADING = int.Parse(data["Map"]["MAX_TIME_LOADING"]);
        }

        public static void NamesMapRead()
        {
            string[] lines = File.ReadAllLines(GetPath("names_maps.txt"));
            int len = lines.Length;
            for(int i = 0; i < len; ++i)
                mapName[i] = lines[i];
        }

        public static Vector3 FlagPositionRead(string section)
        {
            var data = new IniDataParser().Parse(iniFile);
            string[] position = data[section][GetCurrentMap()].Split(',');
            return new Vector3(Double(position[0]), Double(position[1]), Double(position[2]));
        }

        public static void SpawnPositionRead()
        {
            string[] lines = File.ReadAllLines(GetPath($"spawn_position{Path.DirectorySeparatorChar}{GetCurrentMap()}.txt"));
            string[] position;
            int len = lines.Length - 1;
            int j = 0;
            Interior = int.Parse(lines[len]);
            for(int i = 0; i < MAX_SPAWNS; ++i)
            {
                position = lines[i].Split(',');
                spawns[(int)TeamID.Alpha, i].X = Double(position[0]);
                spawns[(int)TeamID.Alpha, i].Y = Double(position[1]);
                spawns[(int)TeamID.Alpha, i].Z = Double(position[2]);
                spawns[(int)TeamID.Alpha, i].Angle = Float(position[3]);
            }

            for (int i = MAX_SPAWNS + 1; i < len; ++i)
            {
                position = lines[i].Split(',');
                spawns[(int)TeamID.Beta, j].X = Double(position[0]);
                spawns[(int)TeamID.Beta, j].Y = Double(position[1]);
                spawns[(int)TeamID.Beta, j].Z = Double(position[2]);
                spawns[(int)TeamID.Beta, j++].Angle = Float(position[3]);
            }
        }
    }
}
