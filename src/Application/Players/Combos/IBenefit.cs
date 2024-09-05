namespace CTF.Application.Players.Combos;

public interface IBenefit
{
    string Name { get; }
    int RequiredPoints { get; }
    void Give(Player player);
}
