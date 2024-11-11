namespace CTF.Application.Players.Weapons;

public interface IWeapon
{
    const int UnlimitedAmmo = 99999999;
    Weapon Id { get; }
    string Name { get; }
    int Slot { get; }
    bool Is(Weapon weapon);
    bool IsNot(Weapon weapon);
}
