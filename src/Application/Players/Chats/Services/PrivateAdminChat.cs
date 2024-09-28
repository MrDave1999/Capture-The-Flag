namespace CTF.Application.Players.Chats.Services;

public class PrivateAdminChat(IEntityManager entityManager) : IChatMessage
{
    public char Id => '#';
    public bool SendToAllPlayers(PlayerInfo sender, string message)
    {
        if (sender.HasLowerRoleThan(RoleId.Admin))
            return false;

        var players = entityManager.GetComponents<Player>();
        foreach (Player player in players)
        {
            if (player.IsInClassSelection())
                continue;

            PlayerInfo playerInfo = player.GetInfo();
            if (playerInfo.HasLowerRoleThan(RoleId.Admin))
                continue;

            player.SendClientMessage(new Color(0x33FF33AA), $"[Admin Chat] {player.Name}: {message}");
        }
        return true;
    }
}
