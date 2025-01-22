namespace CTF.Application.Players.AntiCrouchBug;

/// <summary>
/// Represents a component that stores the last shot time and 
/// is used to detect rapid shooting techniques such as C-Bug.
/// </summary>
public class LastFiredTimeComponent : Component
{
    public long Value { get; set; }
}
