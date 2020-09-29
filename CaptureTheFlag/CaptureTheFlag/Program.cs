using SampSharp.Core;

namespace CaptureTheFlag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new GameModeBuilder()
                .Use<GameMode>()
                .Run();
        }
    }
}
