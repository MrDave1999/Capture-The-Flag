﻿namespace CTF.Application.Players.Accounts.Systems;

public class ChangeNameSystem(
    IPlayerRepository playerRepository,
    IWorldService worldService) : ISystem
{
    [PlayerCommand("changename")]
    public void ChangeName(Player player, string newName)
    {
        if(playerRepository.Exists(newName)) 
        {
            player.SendClientMessage(Color.Red, Messages.PlayerNameAlreadyExists);
            return;
        }

        PlayerInfo playerInfo = player.GetComponent<AccountComponent>().PlayerInfo;
        string oldName = playerInfo.Name;
        Result result = playerInfo.SetName(newName);
        if (result.IsFailed)
        {
            player.SendClientMessage(Color.Red, result.Message);
            return;
        }

        var message = Smart.Format(Messages.ChangeName, new { OldName = oldName, NewName = newName });
        worldService.SendClientMessage(Color.Yellow, message);
        player.Name = newName;
        playerRepository.UpdateName(playerInfo);
    }
}
