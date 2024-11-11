namespace CTF.Application.Maps;

public class SpawnLocation
{
    public static readonly SpawnLocation Empty = new(0, 0, 0, 0);
    public Vector3 Position { get; }
    public float Angle { get; }
    public SpawnLocation(float x, float y, float z, float angle)
    {
        Position = new Vector3(x, y, z);
        Angle = angle;
    }

    public SpawnLocation(Vector3 position, float angle)
    {
        Position = position;
        Angle = angle;
    }
}
