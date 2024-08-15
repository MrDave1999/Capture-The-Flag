namespace CTF.Application.Flags;

internal class Flag
{
    public required FlagModel Model { get; init; }
    public required string Name { get; init; } = string.Empty;
    public required Color ColorHex { get; init; }

    /// <summary>
    /// Represents the player that holds the flag.
    /// </summary>
    /// <remarks>
    /// It is <c>null</c> when no player holds the flag.
    /// </remarks>
    public Player FlagCarrier { get; private set; }

    /// <summary>
    /// Checks if the flag has been captured by a player.
    /// </summary>
    public bool IsCaptured() => FlagCarrier is not null;

    /// <summary>
    /// Sets the player who holds the flag.
    /// </summary>
    public void SetCarrier(Player player)
    {
        ArgumentNullException.ThrowIfNull(player);
        FlagCarrier = player;
        player.SetAttachedObject(
            index: 0, 
            modelId: (int)Model, 
            bone: Bone.Spine, 
            offset: new Vector3(-0.057000, -0.108999, 0.075000), 
            rotation: new Vector3(171.500030, 66.200012, -4.100002), 
            scale: new Vector3(1.0, 1.0, 1.0), 
            materialColor1: ColorHex,
            materialColor2: ColorHex);
    }

    /// <summary>
    /// Removes the flag that the player is holding.
    /// </summary>
    public void RemoveCarrier()
    {
        if (FlagCarrier is not null)
        {
            FlagCarrier.RemoveAttachedObject(0);
            FlagCarrier = default;
        }
    }
}
