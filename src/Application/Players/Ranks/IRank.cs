namespace CTF.Application.Players.Ranks;

internal interface IRank
{
    public RankId Id { get; }
    public string Name { get; }
    public int RequiredKills { get; }
    public bool IsMax();
    public bool IsNotMax();
}
