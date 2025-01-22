namespace CTF.Application.Players.AntiCBug;

public class AntiCBugCommands(
    IWorldService worldService,
    AntiCBugSettings antiCBugSettings) : ISystem
{
    [PlayerCommand("anticbugoff")]
    public void Disable(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.Admin))
            return;

        var message = Smart.Format(Messages.DisableAntiCBug, new
        {
            PlayerName = player.Name
        });
        worldService.SendClientMessage(Color.Yellow, message);
        antiCBugSettings.Disabled = true;
    }

    [PlayerCommand("anticbugon")]
    public void Enable(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.Admin))
            return;

        var message = Smart.Format(Messages.EnableAntiCBug, new
        {
            PlayerName = player.Name
        });
        worldService.SendClientMessage(Color.Yellow, message);
        antiCBugSettings.Disabled = false;
    }
}
