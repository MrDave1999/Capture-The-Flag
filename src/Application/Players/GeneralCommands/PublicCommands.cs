﻿namespace CTF.Application.Players.GeneralCommands;

public class PublicCommands(
    IEntityManager entityManager,
    IDialogService dialogService) : ISystem
{
    [PlayerCommand("kill")]
    public void Kill(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        if (playerInfo.Team == Team.None)
        {
            player.SendClientMessage(Color.Red, Messages.NoTeam);
            return;
        }
        player.Health = 0;
    }

    [PlayerCommand("admins")]
    public void ShowAdmins(Player currentPlayer)
    {
        IEnumerable<PlayerInfo> admins = entityManager
            .GetComponents<Player>()
            .Select(player => player.GetInfo())
            .Where(playerInfo => playerInfo.RoleId >= RoleId.Moderator)
            .OrderByDescending(playerInfo => playerInfo.RoleId);

        int count = admins.Count();
        if (count == 0)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoAdminsConnected);
            return;
        }
        var dialog = new ListDialog(caption: $"Admins: {count}", "Close", "");
        foreach (PlayerInfo playerInfo in admins)
        {
            dialog.Add(playerInfo.Name);
        }
        dialogService.ShowAsync(currentPlayer, dialog);
    }

    [PlayerCommand("vips")]
    public void ShowVIPs(Player currentPlayer)
    {
        IEnumerable<PlayerInfo> vips = entityManager
            .GetComponents<Player>()
            .Select(player => player.GetInfo())
            .Where(playerInfo => playerInfo.RoleId >= RoleId.VIP);

        int count = vips.Count();
        if (count == 0)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoVIPsConnected);
            return;
        }
        var dialog = new ListDialog(caption: $"VIPs: {count}", "Close", "");
        foreach (PlayerInfo playerInfo in vips)
        {
            dialog.Add(playerInfo.Name);
        }
        dialogService.ShowAsync(currentPlayer, dialog);
    }

    [PlayerCommand("report")]
    public void ReportPlayer(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        string reason)
    {
        if(currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        IEnumerable<Player> admins = entityManager
            .GetComponents<Player>()
            .Where(player => player.GetInfo().RoleId >= RoleId.Moderator);

        if(!admins.Any()) 
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoAdminsConnected);
            return;
        }

        var message = Smart.Format(Messages.ReportToAnotherPlayer, new
        {
            CurrentPlayer = currentPlayer.Name,
            TargetPlayer = targetPlayer.Name,
            Reason = reason
        });
        foreach(Player player in admins) 
        { 
            player.SendClientMessage(Color.Red, message);
        }
        currentPlayer.SendClientMessage(Color.Yellow, Messages.ReportSuccessfullySent);
        currentPlayer.PlaySound(1058);
    }
}
