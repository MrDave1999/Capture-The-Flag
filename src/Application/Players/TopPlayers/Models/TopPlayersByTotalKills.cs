namespace CTF.Application.Players.TopPlayers.Models;

public class TopPlayersByTotalKills
{
    public string PlayerName { get; init; }
    public int TotalKills { get; init; }
    public RankId Rank { get; init; }
}
