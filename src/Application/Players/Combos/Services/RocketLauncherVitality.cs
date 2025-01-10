﻿namespace CTF.Application.Players.Combos.Services;

public class RocketLauncherVitality(ComboSettings comboSettings) : ICombo
{
    public string Name => "100 Health and Rocket launcher(RPG)";
    public int RequiredCoins => 100;

    public Result Give(Player player)
    {
        if (comboSettings.IsRocketLauncherDisabled)
        {
            player.SendClientMessage(Color.Red, Messages.RocketLauncherDisabled);
            return Result.Failure();
        }

        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 100;
        player.GiveWeapon(Weapon.RocketLauncher, ammo: 2);
        playerInfo.StatsPerRound.ResetCoins();
        return Result.Success();
    }
}
