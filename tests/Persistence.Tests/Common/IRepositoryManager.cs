namespace Persistence.Tests.Common;

public interface IRepositoryManager : IDisposable
{
    IPlayerRepository PlayerRepository { get; }
    ITopPlayersRepository TopPlayersRepository { get; }
    void InitializeSeedData();
    void RemoveSeedData();
}
