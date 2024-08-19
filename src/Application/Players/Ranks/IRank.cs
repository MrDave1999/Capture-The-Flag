namespace CTF.Application.Players.Ranks;

public interface IRank
{
    RankId Id { get; }
    string Name { get; }
    int RequiredKills { get; }
    bool IsMax();
    bool IsNotMax();
}
