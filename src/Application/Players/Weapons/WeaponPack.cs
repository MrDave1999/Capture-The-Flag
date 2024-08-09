namespace CTF.Application.Players.Weapons;

internal class WeaponPack : IEnumerable<IWeapon>
{
    private readonly List<IWeapon> _weapons =
    [
        GtaWeapons.GetById(Weapon.Knife).Value,
        GtaWeapons.GetById(Weapon.Deagle).Value
    ];

    public int Items => _weapons.Count;
    public IWeapon this[int index] => _weapons[index];
    public bool IsEmpty() => _weapons.Count == 0;
    public void Add(IWeapon weapon)
    {
        ArgumentNullException.ThrowIfNull(weapon);
        // GTA San Andreas does not allow a player to have two weapons with the same slot.
        // Checks if there is no weapon with the same slot in the player's weapon pack.
        int index = _weapons.FindIndex(w => w.Slot == weapon.Slot);
        bool hasWeaponWithSameCategory = index != -1;
        if (hasWeaponWithSameCategory)
            _weapons[index] = weapon;
        else
            _weapons.Add(weapon);
    }
    public void Remove(IWeapon weapon) => _weapons.Remove(weapon);
    public bool Exists(IWeapon weapon) => _weapons.Find(w => w == weapon) is not null;
    public void Clear() => _weapons.Clear();
    public IEnumerator<IWeapon> GetEnumerator() => _weapons.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
