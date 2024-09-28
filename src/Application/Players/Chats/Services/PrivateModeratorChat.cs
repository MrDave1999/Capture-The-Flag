﻿namespace CTF.Application.Players.Chats.Services;

public class PrivateModeratorChat(IEntityManager entityManager) : IChatMessage
{
    public char Id => '&';
    public bool SendToAllPlayers(PlayerInfo sender, string message)
    {
        if (sender.HasLowerRoleThan(RoleId.Moderator))
            return false;

        var players = entityManager.GetComponents<Player>();
        foreach (Player player in players)
        {
            if (player.IsInClassSelection())
                continue;

            PlayerInfo playerInfo = player.GetInfo();
            if (playerInfo.HasLowerRoleThan(RoleId.Moderator))
                continue;

            player.SendClientMessage(Color.Yellow, $"[Moderator Chat] {player.Name}: {message}");
        }
        return true;
    }
}
