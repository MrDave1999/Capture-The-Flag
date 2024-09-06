namespace CTF.Application.Players.Combos.Services;

public class MolotovVitality : ICombo
{
    public string Name => "100 Health, 100 Armour and 25 Molotov cocktail";
    public int RequiredPoints => 100;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 100;
        player.Armour = 100;
        player.GiveWeapon(Weapon.Moltov, ammo: 25);
        playerInfo.StatsPerRound.ResetPoints();
    }
}
