namespace CTF.Application.Teams.Flags.Events;

/// <summary>
/// This event occurs when a player attempts to pick up their own team's flag, which is currently at the base.
/// </summary>
public class OnFlagAtBasePosition : IFlagEvent
{
    public FlagStatus FlagStatus => FlagStatus.InitialPosition;

    public void Handle(Team team, Player player)
    {
        var text = Smart.Format(Messages.OnFlagAtBasePosition, new { GameText = team.GameText });
        player.GameText(text, 5000, 3);
    }
}
