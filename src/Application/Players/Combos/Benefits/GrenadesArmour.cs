namespace CTF.Application.Players.Combos.Benefits;

public class GrenadesArmour : IBenefit
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
