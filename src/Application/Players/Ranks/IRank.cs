namespace CTF.Application.Players.Ranks;

internal interface IRank
{
    RankId Id { get; }
    string Name { get; }
    int RequiredKills { get; }
    bool IsMax();
    bool IsNotMax();
}
