namespace Persistence.InMemory;

internal class FakeTopPlayersRepository(
    Dictionary<int, FakePlayer> players,
    TopPlayersSettings settings) : ITopPlayersRepository
{
    public IEnumerable<TopPlayersByMaxKillingSpree> GetByMaxKillingSpree(MaxTopPlayers maxPlayers)
        => players
            .Where(kvp => kvp.Value.MaxKillingSpree >= settings.RequiredMaxKillingSpree)
            .OrderByDescending(x => x.Value.MaxKillingSpree)
            .Select(kvp => new TopPlayersByMaxKillingSpree
            {
                PlayerName      = kvp.Value.Name,
                MaxKillingSpree = kvp.Value.MaxKillingSpree
            })
            .Take(maxPlayers.Value)
            .ToArray();

    public IEnumerable<TopPlayersByTotalKills> GetByTotalKills(MaxTopPlayers maxPlayers)
        => players
            .Where(kvp => kvp.Value.TotalKills >= settings.RequiredTotalKills)
            .OrderByDescending(kvp => kvp.Value.TotalKills)
            .Select(kvp => new TopPlayersByTotalKills
            {
                PlayerName = kvp.Value.Name,
                TotalKills = kvp.Value.TotalKills,
                Rank       = kvp.Value.RankId
            })
            .Take(maxPlayers.Value)
            .ToArray();
}
