namespace CTF.Application.Players.TopPlayers;

public interface ITopPlayersRepository
{
    /// <summary>
    /// Retrieves a collection of top players sorted by total kills.
    /// </summary>
    /// <param name="maxPlayers">The maximum number of players to retrieve.</param>
    IEnumerable<TopPlayersByTotalKills> GetByTotalKills(MaxTopPlayers maxPlayers);

    /// <summary>
    /// Retrieves a collection of top players sorted by maximum killing sprees.
    /// </summary>
    /// <param name="maxPlayers">The maximum number of players to retrieve.</param>
    IEnumerable<TopPlayersByMaxKillingSpree> GetByMaxKillingSpree(MaxTopPlayers maxPlayers);
}
