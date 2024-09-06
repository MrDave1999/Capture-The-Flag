namespace CTF.Application.Players.Combos.Services;

public class SatchelChargesVitality : ICombo
{
    public string Name => "100 Health, 100 Armour and 25 Satchel charges";
    public int RequiredPoints => 100;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 100;
        player.Armour = 100;
        player.GiveWeapon(Weapon.SatchelCharge, ammo: 25);
        player.GiveWeapon(Weapon.Detonator, ammo: 1);
        playerInfo.StatsPerRound.ResetPoints();
    }
}
