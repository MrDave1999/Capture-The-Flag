namespace CaptureTheFlag.Teams;

public class Flag
{
    public Player PlayerCaptured { get; set; } 
    public bool IsPositionBase { get; set; } = true; 
    public Color ColorHex { get; private set; }
    public int Model { get; private set; }
    public Vector3 PositionBase { get; set; }
    private Pickup Pickup { get; set; }

    public Flag(int modelid, Color color, Vector3 vector3)
    {
        ColorHex = color;
        Model = modelid;
        PositionBase = vector3;
        Create();
    }

    public void AttachedObject(Player player)
        => player.SetAttachedObject(0, Model, Bone.Spine, new Vector3(-0.057000, -0.108999, 0.075000), new Vector3(171.500030, 66.200012, -4.100002), new Vector3(1.0, 1.0, 1.0), ColorHex, ColorHex);

    public void Create(Vector3 vector3)
    {
        Pickup = Pickup.Create(Model, 1, vector3);
        PositionBase = vector3;
    }

    public void Create()
        => Pickup = Pickup.Create(Model, 1, PositionBase);


    public void Create(Player player)
        => Pickup = Pickup.Create(Model, 1, player.Position);

    public void Delete()
        => Pickup.Dispose();

    public void DeletePlayerCaptured()
    {
        if (PlayerCaptured != null)
        {
            PlayerCaptured.RemoveAttachedObject(0);
            PlayerCaptured = null;
        }
        IsPositionBase = true;
    }

    public static void RemoveAll()
    {
        foreach(Pickup pickup in Pickup.GetAll<Pickup>())
            pickup.Dispose();
    }
}
