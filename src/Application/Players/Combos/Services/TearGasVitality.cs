namespace CTF.Application.Players.Combos.Services;

public class TearGasVitality : ICombo
{
    public string Name => "100 Health, 100 Armour and Tear gas";
    public int RequiredPoints => 100;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 100;
        player.Armour = 100;
        player.GiveWeapon(Weapon.Teargas, ammo: 15);
        playerInfo.StatsPerRound.ResetPoints();
    }
}
