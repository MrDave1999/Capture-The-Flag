using SampSharp.Core;
using System.IO;
using System.Reflection;

namespace CaptureTheFlag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new GameModeBuilder()
                .UseEncoding(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "codepages"+ Path.DirectorySeparatorChar + "cp1252.txt"))
                .Use<GameMode>()
                .Run();
        }
    }
}
