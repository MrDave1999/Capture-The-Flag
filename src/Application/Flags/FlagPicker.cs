namespace CTF.Application.Flags;

/// <summary>
/// Represents the player who picks up the flag.
/// </summary>
internal readonly ref struct FlagPicker
{
    public required int Id { get; init; }
    public required TeamId TeamId { get; init; }
}
