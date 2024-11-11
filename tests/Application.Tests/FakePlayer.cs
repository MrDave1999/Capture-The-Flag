namespace CTF.Application.Tests;

public class FakePlayer : Player
{
    private float _health = 100;
    private float _armour = 0;
    private int _score = 0;
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

    public override float Health 
    { 
        get => _health; 
        set => _health = value; 
    }

    public override float Armour
    {
        get => _armour;
        set => _armour = value;
    }

    public override int Score
    {
        get => _score;
        set => _score = value;
    }
}
