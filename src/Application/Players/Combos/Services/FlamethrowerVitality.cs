namespace CTF.Application.Players.Combos.Services;

public class FlamethrowerVitality : ICombo
{
    public string Name => "100 Health, 100 Armour and FlameThrower";
    public int RequiredPoints => 100;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 100;
        player.Armour = 100;
        // 5500 (shows in game as 500-50).
        const int ammo = 5500;
        player.GiveWeapon(Weapon.FlameThrower, ammo);
        playerInfo.StatsPerRound.ResetPoints();
    }
}
