namespace CTF.Application.Players.AFK;

public static class PlayerPauseExtensions
{
    public static bool IsPaused(this Player player)
        => player.GetComponent<PlayerDataComponent>().IsPaused;
}
