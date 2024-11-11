namespace CTF.Application.Tests.Maps;

public class GetNextMapTestCases : IEnumerable<(IMap Map, IMap Expected)>
{
    public IEnumerator<(IMap Map, IMap Expected)> GetEnumerator()
    {
        yield return (GetCurrentMap(0),  GetNextMap(1));
        yield return (GetCurrentMap(1),  GetNextMap(2));
        yield return (GetCurrentMap(2),  GetNextMap(3));
        yield return (GetCurrentMap(3),  GetNextMap(4));
        yield return (GetCurrentMap(4),  GetNextMap(5));
        yield return (GetCurrentMap(5),  GetNextMap(6));
        yield return (GetCurrentMap(6),  GetNextMap(7));
        yield return (GetCurrentMap(7),  GetNextMap(8));
        yield return (GetCurrentMap(31), GetNextMap(32));
        yield return (
            GetCurrentMap(MapCollection.Count - 1), 
            GetNextMap(0)
        );
    }

    private static IMap GetCurrentMap(int id) => MapCollection.GetById(id).Value;
    private static IMap GetNextMap(int id) => MapCollection.GetById(id).Value;
    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
}
