using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CaptureTheFlag.Utils
{
    public class Scriptfiles
    {
        public static string GetPath(string path)
            => Path.Combine(Environment.CurrentDirectory, $"scriptfiles{Path.DirectorySeparatorChar}{path}");
    }
}
