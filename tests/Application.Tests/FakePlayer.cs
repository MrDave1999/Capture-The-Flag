namespace CTF.Application.Tests;

public class FakePlayer : Player
{
    private readonly int _id;
    private readonly Guid _type;
    public FakePlayer(int id, string name, TeamId team = TeamId.NoTeam)
    {
        _id = id;
        _type = Guid.NewGuid();
        Name = name;
        Team = (int)team;
    }

    public override string Name { get; set; }
    public override int Team { get; set; }
    public override EntityId Entity => new(_type, _id);
    public override bool RemoveAttachedObject(int index) => true;
    public override bool SetAttachedObject(
        int index,
        int modelId,
        Bone bone,
        Vector3 offset,
        Vector3 rotation,
        Vector3 scale,
        Color materialColor1,
        Color materialColor2) => true;
}
