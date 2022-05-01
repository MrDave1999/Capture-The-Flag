namespace CaptureTheFlag.Utils;

public class Scriptfiles
{
    public static string GetPath(string path)
        => Path.Combine(Environment.CurrentDirectory, $"scriptfiles{Path.DirectorySeparatorChar}{path}");
}
