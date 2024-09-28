namespace CTF.Application.Players.Chats.Services;

public class PrivateVipChat : IChatMessage
{
    public char Id => '$';
    public bool SendToAllPlayers(PlayerInfo sender, string message)
    {
        if (sender.HasLowerRoleThan(RoleId.VIP))
            return false;

        var players = AlphaBetaTeamPlayers.GetAll();
        foreach (Player player in players)
        {
            if (player.HasLowerRoleThan(RoleId.VIP))
                continue;

            player.SendClientMessage($"{{8b0000}}[Vip Chat] {player.Name}: {message}");
        }
        return true;
    }
}
