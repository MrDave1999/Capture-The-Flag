namespace Persistence.Tests.Common;

public interface IRepositoryManager : IDisposable
{
    IPlayerRepository PlayerRepository { get; }
}
