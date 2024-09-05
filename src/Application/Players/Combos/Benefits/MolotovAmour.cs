namespace CTF.Application.Players.Combos.Benefits;

public class MolotovAmour : IBenefit
{
    public string Name => "2 Molotov cocktail and 20 Armour";
    public int RequiredPoints => 25;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.GiveWeapon(Weapon.Moltov, ammo: 2);
        player.AddArmour(20);
        playerInfo.StatsPerRound.SubtractPoints(-25);
    }
}
