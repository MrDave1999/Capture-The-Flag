namespace CTF.Application.Players.Chats.Services;

public class PrivateModeratorChat : IChatMessage
{
    public char Id => '&';
    public bool SendToAllPlayers(PlayerInfo sender, string message)
    {
        if (sender.HasLowerRoleThan(RoleId.Moderator))
            return false;

        var players = AlphaBetaTeamPlayers.GetAll();
        foreach (Player player in players)
        {
            if (player.HasLowerRoleThan(RoleId.Moderator))
                continue;

            player.SendClientMessage(Color.Yellow, $"[Moderator Chat] {player.Name}: {message}");
        }
        return true;
    }
}
