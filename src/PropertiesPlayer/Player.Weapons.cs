namespace CaptureTheFlag.PropertiesPlayer;

public partial class Player : BasePlayer
{
    public List<Gun> ListGuns { get; set; } = new List<Gun>(10)
    {
        Gun.GetWeapon(GunID.Deagle),
        Gun.GetWeapon(GunID.Shotgun),
        Gun.GetWeapon(GunID.Sniper)
    };

    public void RemoveWeapon(int index)
    {
        ResetWeapons();
        ListGuns.RemoveAt(index);
        foreach (Gun gun in ListGuns)
            GiveWeapon(gun.Weapon);
    }

    public void GiveWeapon(Weapon weapon) => GiveWeapon(weapon, 99999999);

    public void SetWeapon(Weapon weapon, int ammo)
    {
        SetAmmo(weapon, 0);
        GiveWeapon(weapon, ammo);
    }
}
