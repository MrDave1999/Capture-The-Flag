namespace CTF.Application.Players.Combos;

/// <summary>
/// Represents a combination of different advantages, such as health, armour, and weapons, 
/// that a player can use to gain an advantage in the game.
/// </summary>
public interface ICombo
{
    string Name { get; }
    int RequiredPoints { get; }
    void Give(Player player);
}
