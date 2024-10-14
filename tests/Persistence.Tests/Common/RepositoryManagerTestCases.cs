namespace Persistence.Tests.Common;

public class RepositoryManagerTestCases : IEnumerable<IRepositoryManager>
{
    public IEnumerator<IRepositoryManager> GetEnumerator()
    {
        yield return new InMemoryRepositoryManager();
        yield return new MariaDbRepositoryManager();
    }

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
}
