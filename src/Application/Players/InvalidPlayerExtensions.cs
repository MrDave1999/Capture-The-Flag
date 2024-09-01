namespace CTF.Application.Players;

public static class InvalidPlayerExtensions
{
    public static bool IsInvalidPlayer(this Player player) => player is null;
    public static bool IsValidPlayer(this Player player) => player is not null;
}
