namespace CTF.Application.Players.GeneralCommands;

public class VipCommands : ISystem
{
    [PlayerCommand("saw")]
    public void Saw(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        player.GiveWeapon(Weapon.Chainsaw, 1);
    }

    [PlayerCommand("spray")]
    public void Spray(Player player) 
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        player.GiveWeapon(Weapon.Spraycan, IWeapon.UnlimitedAmmo);
    }

    [PlayerCommand("teargas")]
    public void Teargas(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        player.GiveWeapon(Weapon.Teargas, IWeapon.UnlimitedAmmo);
    }
}
