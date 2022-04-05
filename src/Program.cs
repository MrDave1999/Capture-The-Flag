using CaptureTheFlag.Events;
using CaptureTheFlag.Utils;
using SampSharp.Core;

try
{
    new GameModeBuilder()
        .RedirectConsoleOutput()
        .UseEncoding(Scriptfiles.GetPath($"codepages{Path.DirectorySeparatorChar}cp1252.txt"))
        .Use<GameMode>()
        .Run();
}
catch (Exception e)
{
    Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
}