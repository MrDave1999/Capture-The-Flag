﻿namespace CTF.Application.Players.Combos.Services;

public class MolotovVitality : ICombo
{
    public string Name => "100 Health, 100 Armour and Molotov cocktail";
    public int RequiredCoins => 100;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 100;
        player.Armour = 100;
        player.GiveWeapon(Weapon.Moltov, ammo: 6);
        playerInfo.StatsPerRound.ResetCoins();
    }
}
