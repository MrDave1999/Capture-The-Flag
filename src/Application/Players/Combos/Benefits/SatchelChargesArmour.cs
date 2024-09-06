namespace CTF.Application.Players.Combos.Benefits;

public class SatchelChargesArmour : IBenefit
{
    public string Name => "4 Satchel charges and 30 Armour";
    public int RequiredPoints => 40;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.GiveWeapon(Weapon.SatchelCharge, ammo: 4);
        player.GiveWeapon(Weapon.Detonator, ammo: 1);
        player.AddArmour(30);
        playerInfo.StatsPerRound.SubtractPoints(-40);
    }
}
