namespace CTF.Application.Maps;

public class FlagLocations
{
    public static readonly FlagLocations Empty = new()
    {
        Red  = new Vector3(0, 0, 0),
        Blue = new Vector3(0, 0, 0)
    };

    public required Vector3 Red { get; init; }
    public required Vector3 Blue { get; init; }
}
