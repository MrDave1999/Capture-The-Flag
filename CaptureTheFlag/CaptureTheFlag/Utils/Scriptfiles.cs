using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CaptureTheFlag.Utils
{
    public class Scriptfiles
    {
        public static string GetPath(string filename)
            => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "scriptfiles" + Path.DirectorySeparatorChar + filename);
    }
}
