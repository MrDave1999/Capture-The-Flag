namespace CTF.Application.Players.Weapons;

internal class WeaponSelectionComponent : Component
{
    public WeaponPack SelectedWeapons { get; } = new();
}
