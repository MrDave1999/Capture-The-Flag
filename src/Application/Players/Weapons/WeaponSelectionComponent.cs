namespace CTF.Application.Players.Weapons;

internal class WeaponSelectionComponent : Component
{
    public List<IWeapon> SelectedWeapons { get; } = 
    [
        GtaWeapons.GetById(Weapon.Knife).Value,
        GtaWeapons.GetById(Weapon.Deagle).Value
    ];
}
