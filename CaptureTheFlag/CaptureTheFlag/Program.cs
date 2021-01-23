using CaptureTheFlag.Events;
using SampSharp.Core;
using System;
using System.IO;
using System.Reflection;

namespace CaptureTheFlag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new GameModeBuilder()
                    .RedirectConsoleOutput()
                    .UseEncoding(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "codepages" + Path.DirectorySeparatorChar + "cp1252.txt"))
                    .Use<GameMode>()
                    .Run();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }
    }
}
