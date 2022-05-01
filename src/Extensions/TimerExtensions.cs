namespace CaptureTheFlag;

public static class TimerExtensions
{
    public static void Start(this Timer timer)
        => timer.IsRunning = true;

    public static void Stop(this Timer timer)
        => timer.IsRunning = false;
}
