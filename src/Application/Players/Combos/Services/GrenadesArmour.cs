namespace CTF.Application.Players.Combos.Services;

public class GrenadesArmour : ICombo
{
    public string Name => "2 Grenades and 20 Armour";
    public int RequiredPoints => 25;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.GiveWeapon(Weapon.Grenade, ammo: 2);
        player.AddArmour(20);
        playerInfo.StatsPerRound.SubtractPoints(-25);
    }
}
