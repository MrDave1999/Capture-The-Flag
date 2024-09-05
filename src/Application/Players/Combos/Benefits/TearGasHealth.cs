namespace CTF.Application.Players.Combos.Benefits;

public class TearGasHealth : IBenefit
{
    public string Name => "20 Tear gas and 30 Health";
    public int RequiredPoints => 20;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.GiveWeapon(Weapon.Teargas, ammo: 20);
        player.AddHealth(30);
        playerInfo.StatsPerRound.SubtractPoints(-20);
    }
}
