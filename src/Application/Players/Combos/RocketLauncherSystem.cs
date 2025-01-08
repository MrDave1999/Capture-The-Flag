namespace CTF.Application.Players.Combos;

public class RocketLauncherSystem(
    IWorldService worldService,
    ComboSettings comboSettings) : ISystem
{
    [PlayerCommand("rpgon")]
    public void EnableRocketLauncher(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.Moderator))
            return;

        var message = Smart.Format(Messages.EnableRocketLauncher, new
        {
            PlayerName = player.Name
        });
        worldService.SendClientMessage(Color.Yellow, message);
        comboSettings.IsRocketLauncherDisabled = false;
    }

    [PlayerCommand("rpgoff")]
    public void DisableRocketLauncher(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.Moderator))
            return;

        var message = Smart.Format(Messages.DisableRocketLauncher, new
        {
            PlayerName = player.Name
        });
        worldService.SendClientMessage(Color.Yellow, message);
        comboSettings.IsRocketLauncherDisabled = true;
    }
}
