namespace CTF.Application.Players.Chats.Services;

public class PrivateAdminChat : IChatMessage
{
    public char Id => '#';
    public bool SendToAllPlayers(PlayerInfo sender, string message)
    {
        if (sender.HasLowerRoleThan(RoleId.Admin))
            return false;

        var players = AlphaBetaTeamPlayers.GetAll();
        foreach (Player player in players)
        {
            if (player.HasLowerRoleThan(RoleId.Admin))
                continue;

            player.SendClientMessage(new Color(0x33FF33AA), $"[Admin Chat] {player.Name}: {message}");
        }
        return true;
    }
}
