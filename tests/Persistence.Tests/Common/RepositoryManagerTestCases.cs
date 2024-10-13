namespace Persistence.Tests.Common;

public class RepositoryManagerTestCases : IEnumerable<IRepositoryManager>
{
    public IEnumerator<IRepositoryManager> GetEnumerator()
    {
        yield return new InMemoryRepositoryManager();
    }

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
}
