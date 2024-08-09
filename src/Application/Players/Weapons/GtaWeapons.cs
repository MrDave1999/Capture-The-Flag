namespace CTF.Application.Players.Weapons;

internal class GtaWeapons
{
    private static readonly GtaWeapon[] s_weapons =
    [
        new(Weapon.Knife,           1),
        new(Weapon.Silenced,        2),
        new(Weapon.Deagle,          2),
        new(Weapon.Shotgun,         3),
        new(Weapon.CombatShotgun,   3),
        new(Weapon.MP5,             4),
        new(Weapon.AK47,            5),
        new(Weapon.M4,              5),
        new(Weapon.Sniper,          6),
        new(Weapon.Rifle,           6)
    ];

    private GtaWeapons() { }
    public static int Max => s_weapons.Length;
    public static IReadOnlyList<IWeapon> GetAll() => s_weapons;
    public static Result<IWeapon> GetById(Weapon id)
    {
        GtaWeapon weapon = s_weapons.FirstOrDefault(weapon => weapon.Id == id);
        return weapon is null ? 
            Result<IWeapon>.Failure(Messages.WeaponNotFound) : 
            Result<IWeapon>.Success(weapon);
    }
    public static Result<IWeapon> GetByIndex(int index)
    {
        if(index < 0 || index >= Max)
            return Result<IWeapon>.Failure(Messages.InvalidWeapon);

        GtaWeapon weapon = s_weapons[index];
        return Result<IWeapon>.Success(weapon);
    }
    public static Result<IWeapon> GetByName(string weaponName)
    {
        ArgumentNullException.ThrowIfNull(weaponName);
        GtaWeapon weapon = s_weapons
            .FirstOrDefault(weapon => weapon.Name.Equals(weaponName, StringComparison.OrdinalIgnoreCase));
        return weapon is null ?
            Result<IWeapon>.Failure(Messages.WeaponNotFound) :
            Result<IWeapon>.Success(weapon);
    }

    private class GtaWeapon : IWeapon
    {
        public Weapon Id { get; }
        public string Name { get; }
        public int Slot { get; }

        public GtaWeapon(Weapon id, int slot)
        {
            Id = id;
            Name = id.ToString();
            Slot = slot;
        }
        public bool Is(Weapon weapon) => Id == weapon;
        public bool IsNot(Weapon weapon) => !Is(weapon);
    }
}
